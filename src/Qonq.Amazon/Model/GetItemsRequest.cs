using System.Text.Json.Serialization;

namespace Qonq.Amazon.Model
{
    public class GetItemsRequest : AmazonRequest
    {
        public string[] ItemIds { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Condition? Condition { get; set; }
        public GetItemsRequest(string[] itemIds, string partnerTag, string partnerType, string marketplace) : base(partnerTag, partnerType, marketplace)
        {
            ItemIds = itemIds;
        }

    }
}
