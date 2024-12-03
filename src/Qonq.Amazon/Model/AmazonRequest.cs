
using System.Text.Json.Serialization;

namespace Qonq.Amazon.Model
{
    public abstract class AmazonRequest
    {

        public string PartnerTag { get; internal set; } = "";
        public string PartnerType { get; internal set; } = "";
        public string Marketplace { get; internal set; } = "";
        public string[]? Resources { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Merchant? Merchant { get; set; }
        protected AmazonRequest(string partnerTag, string partnerType, string marketplace)
        {
            PartnerTag = partnerTag;
            PartnerType = partnerType;
            Marketplace = marketplace;
        }

    }
}
