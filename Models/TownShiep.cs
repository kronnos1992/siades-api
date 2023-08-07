using siades.Default;

namespace siades.Models
{
    public class TownShiep : EntityDefault
    {
        public TownShiep()
        {
            AddressesList = new HashSet<Address>();
        }
        public string? TownName { get; set; }
        public Province? GetProvince { get; set; }
        public ICollection<Address>? AddressesList { get; set; }
    }
}