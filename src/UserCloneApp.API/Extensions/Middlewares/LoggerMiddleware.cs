using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.Json;
using UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetToken;
using UserCloneApp.Application.DTOs.ResponseDTOs;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Exceptions;
using UserCloneApp.Domain.Models.ConstantModels;
using UserCloneApp.Domain.Models.LogModels;

namespace UserCloneApp.API.Extensions.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            HttpRequest request = context.Request;

            Stopwatch stopwatch = Stopwatch.StartNew();

            string? correlationId = request.Headers["CorrelationId"].FirstOrDefault();
            if (correlationId == null)
            {
                correlationId = Guid.NewGuid().ToString();
                request.Headers.Add("correlationId", correlationId);
            }

            string? userEmail = TokenHelper.Instance().DecodeTokenInRequest()?.Email;
            if (userEmail == null)
            {
                request.EnableBuffering();
                using StreamReader reader = new(request.Body, Encoding.UTF8, true, 1024, true);
                string requestBody = await reader.ReadToEndAsync();
                request.Body.Position = 0;

                GetTokenQueryRequest? body = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTokenQueryRequest>(requestBody);
                userEmail = body?.Email;
            }

            Exception? exception = null;
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                HttpStatusCode statusCode = exception switch
                {
                    null => HttpStatusCode.OK,
                    ClientSideException => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                };

                if(exception != null)
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    ExceptionConstantModel error = statusCode switch
                    {
                        HttpStatusCode.InternalServerError => ExceptionConstant.ServerSideError,
                        _ => exception is not ClientSideException clientSideException ? ExceptionConstant.ServerSideError : new ExceptionConstantModel(clientSideException.Code, clientSideException.Message)
                    };

                    context.Response.StatusCode = (int)statusCode;

                    APIResponseDTO response = new(statusCode, error);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response,new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }));
                }

                LoggerHelper.Log(new LogModel(
                    elapsedTimeMilliseconds: stopwatch.ElapsedMilliseconds,
                    requestID: correlationId,
                    serviceName: Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown",
                    userEmail: TokenHelper.Instance().DecodeTokenInRequest()?.Email ?? "Unknown",
                    ipAddress: request.Host.ToString(),
                    request: new RequestLogModel(request.Method, request.Path),
                    response: new ResponseLogModel((int)statusCode),
                    error: exception == null ? null : new ErrorLogModel(exception.Message, exception.InnerException?.Message, exception.StackTrace)
                    ));
            }
        }
    }
}
