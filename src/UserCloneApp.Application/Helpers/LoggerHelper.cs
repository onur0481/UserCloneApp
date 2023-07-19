using Serilog.Context;
using Serilog.Core;
using Serilog.Core.Enrichers;
using UserCloneApp.Domain.Models.LogModels;

namespace UserCloneApp.Application.Helpers
{
    public class LoggerHelper
    {
        private static readonly string ElapsedTimeProperty = "ElapsedTime";
        private static readonly string RequestIDProperty = "RequestID";
        private static readonly string ServiceName = "ServiceName";
        private static readonly string UserEmailProperty = "UserEmail";
        private static readonly string IpAddressProperty = "IpAddress";
        private static readonly string RequestProperty = "Request";
        private static readonly string ResponseProperty = "Response";
        private static readonly string ErrorProperty = "Error";

        public static void Log(LogModel logModel)
        {
            LogEnricher(logModel);

            if (logModel.Error != null)
            {
                Serilog.Log.Logger.Error($"{logModel.Request.Method} {logModel.Request.Path}");
            }
            else
            {
                Serilog.Log.Logger.Information($"{logModel.Request.Method} {logModel.Request.Path}");
            }
        }

        private static void LogEnricher(LogModel logModel)
        {
            List<ILogEventEnricher> enrichers = new()
            {
                new PropertyEnricher(ElapsedTimeProperty, logModel.ElapsedTimeMilliseconds),
                new PropertyEnricher(RequestIDProperty, logModel.RequestID),
                new PropertyEnricher(ServiceName, logModel.ServiceName),
                new PropertyEnricher(UserEmailProperty, logModel.UserEmail),
                new PropertyEnricher(IpAddressProperty, logModel.IpAddress),
                new PropertyEnricher(RequestProperty, logModel.Request.ToString()),
                new PropertyEnricher(ResponseProperty, logModel.Response.ToString())
            };

            if(logModel.Error != null)
            {
                enrichers.Add(new PropertyEnricher(ErrorProperty, logModel.Error.ToString()));
            }

            LogContext.Push(enrichers.ToArray());
        }
    }
}
