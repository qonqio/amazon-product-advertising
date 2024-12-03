using System.Text.Json;
using System.Text.Json.Serialization;

namespace Qonq.Amazon.Model
{
    public class GetBrowseNodesRequest : AmazonRequest
    {
        public string[] BrowseNodeIds { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LanguageCodes[] LanguagesOfPreference { get; set; }
        public GetBrowseNodesRequest(string[] browseNodeIds, string partnerTag, string partnerType, string marketplace) : base(partnerTag, partnerType, marketplace)
        {
            BrowseNodeIds = browseNodeIds;
        }

    }
}