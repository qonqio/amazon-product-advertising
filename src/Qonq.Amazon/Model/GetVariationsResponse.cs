using Qonq.Amazon.Model;

namespace Qonq.Amazon.Model
{
    public class GetVariationsResponse : AmazonResponse
    {
        public VariationsResult VariationsResult { get; set; } = default!;
    }
}
