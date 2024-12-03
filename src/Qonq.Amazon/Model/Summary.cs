namespace Qonq.Amazon.Model
{
    public class Summary
    {
        public Condition2? Condition { get; set; }
        public PriceRange? HighestPrice { get; set; }
        public PriceRange? LowestPrice { get; set; }
        public int OfferCount { get; set; }
    }
}
