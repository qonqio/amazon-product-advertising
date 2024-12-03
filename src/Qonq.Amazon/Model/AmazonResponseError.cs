using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qonq.Amazon.Model
{
    public class AmazonResponseError
    {
        [JsonPropertyName("__type")]
        public string Type { get; set; } = "";
        public string Code { get; set; } = "";
        public string Message { get; set; } = "";
    }
}