using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserCloneApp.Domain.Models.LogModels
{
    public class RequestLogModel
    {
        public string Method { get; set; }

        public string Path { get; set; }

        public RequestLogModel(string method, string path)
        {
            Method = method;
            Path = path;
        }

        public override string? ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }
    }
}
