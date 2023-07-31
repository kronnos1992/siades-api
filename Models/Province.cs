using siades.Default;

namespace siades.Models
{
    public class Province : EntityDefault
    {
        public Province()
        {
            TownShiepsList = new HashSet<TownShiep>();
        }
        public string? ProvinceName { get; set; }
        public string? GeoLocation { get; set; }
        
        // Foreign key of country
        public Guid CountryId { get; set; }
        //relacionamento pais e provincia
        public Country? GetCountry { get; set; }

        //relacionamento pais e provincia
        public ICollection<TownShiep>? TownShiepsList { get; set; }
    }
}