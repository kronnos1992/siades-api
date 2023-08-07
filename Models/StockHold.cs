using siades.Default;

namespace siades.Models
{
    public class StockHold
    {
        public string StockHoldId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public string? BloodGroup { get; set; }
        public int Qty { get; set; } = 0;

    }
}