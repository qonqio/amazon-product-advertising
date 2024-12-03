namespace Qonq.Amazon.Model
{
    public class Promotion
    {
        public double Amount { get; set; }
        public string? Currency { get; set; }
        public int DiscountPercent { get; set; }
        public string? DisplayAmount { get; set; }
        public double PricePerUnit { get; set; }
        public string? Type { get; set; }
    }
}
