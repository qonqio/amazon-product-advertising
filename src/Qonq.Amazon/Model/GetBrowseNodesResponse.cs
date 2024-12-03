using Qonq.Amazon.Model;
namespace Qonq.Amazon.Model
{
    public class GetBrowseNodesResponse : AmazonResponse
    {
        public BrowseNodesResult BrowseNodesResult { get; set; } = default!;
    }
}