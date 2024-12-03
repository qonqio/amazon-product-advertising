using Qonq.Amazon.Model;

namespace Qonq.Amazon.Model
{
    public class GetItemsResponse : AmazonResponse
    {
        public ItemsResult ItemsResult { get; set; } = default!;
    }
}
