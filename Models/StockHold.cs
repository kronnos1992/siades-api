using siades.Default;

namespace siades.Models
{
    public class StockHold : EntityDefault
    {
        public int Qty { get; set; }
        public Guid BloodId { get; set; }
        public Blood? GetBlood { get; set; }
        
    }
}