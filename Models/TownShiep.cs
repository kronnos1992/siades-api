using siades.Default;

namespace siades.Models
{
    public class TownShiep : EntityDefault
    {
        public TownShiep()
        {
            AddressesList = new HashSet<Address>();
            BirthAddressesList = new HashSet<BirthAddress>();
        }
        public string? TownName { get; set; }
        // chave estrangeira da provincia
        public Guid ProvinceId { get; set; }        
        // relacionamento municipio provincia
        public Province? GetProvince { get; set; }
        public ICollection<Address>? AddressesList { get; set; }
        public ICollection<BirthAddress>? BirthAddressesList { get; set; }
    }
}