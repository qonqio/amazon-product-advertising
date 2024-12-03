using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qonq.Amazon.Model
{
    public class AmazonResponse
    {
        [JsonPropertyName("__type")]
        public string Type { get; set; } = "";
        public bool Successful { get; set; }
        public string ErrorMessage { get; set; } = "";
        public string Message { get; set; } = "";
        public AmazonResponseError[] Errors { get; set; } = default!;
    }
}
