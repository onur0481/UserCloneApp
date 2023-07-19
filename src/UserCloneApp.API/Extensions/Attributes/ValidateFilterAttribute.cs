using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using UserCloneApp.Application.DTOs.ResponseDTOs;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.API.Extensions.Attributes
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Dictionary<string, string> errorResponse = new();
                foreach (var item in context.ModelState)
                {
                    if (item.Value.Errors.Any())
                    {
                        string[] errorMessages = item.Value.Errors
                            .Select(error => error.ErrorMessage)
                            .ToArray();

                        errorResponse.Add(item.Key, errorMessages.Last());
                    }
                }

                List<ExceptionConstantModel> errors = new();
                foreach (string error in errorResponse.Values)
                {
                    string code = error.Split("<>").First();
                    string message = error.Split("<>").Last();

                    errors.Add(new ExceptionConstantModel(code, message));
                }

                context.Result = new BadRequestObjectResult(new APIResponseDTO(HttpStatusCode.BadRequest, errors));
            }
        }
    }
}

