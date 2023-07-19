using System.Text.Json.Serialization;
using System.Text.Json;

namespace UserCloneApp.Domain.Models.LogModels
{
    public class ErrorLogModel
    {
        public string ErrorMessage { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? InnerExceptionMessage { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StackTrace { get; private set; }

        public ErrorLogModel(string errorMessage, string? innerExceptionMessage = null, string? stackTrace = null)
        {
            ErrorMessage = errorMessage;
            InnerExceptionMessage = innerExceptionMessage;
            StackTrace = stackTrace;
        }

        public override string? ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
