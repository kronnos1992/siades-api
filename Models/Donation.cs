using siades.Default;

namespace siades.Models
{
    [Serializable]
    public class Donation : EntityDefault
    {
        public Guid DonorId { get; set; }
        public Guid StockHoldId { get; set; }
        
        public Donor? GetDonor { get; set; }
        
        public StockHold? GetStock { get; set; }
        
        
    }
}