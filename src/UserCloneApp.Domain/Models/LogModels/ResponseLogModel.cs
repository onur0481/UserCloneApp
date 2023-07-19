using System.Text.Json;

namespace UserCloneApp.Domain.Models.LogModels
{
    public class ResponseLogModel
    {
        public int StatusCode { get; private set; }

        public ResponseLogModel(int statusCode)
        {
            StatusCode = statusCode;
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
