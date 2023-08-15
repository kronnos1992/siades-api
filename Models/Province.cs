using siades.Default;

namespace siades.Models
{
    public class Province : EntityDefault
    {
        public Province()
        {
            TownShiepsList = new HashSet<TownShiep>();
        }
        public string ProvinceName { get; set; }
        public string GeoLocation { get; set; }

        public Country GetCountry { get; set; }

        //relacionamento pais e provincia
        public ICollection<TownShiep> TownShiepsList { get; set; }
    }
}