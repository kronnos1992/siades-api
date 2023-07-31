using siades.Default;

namespace siades.Models;
[Serializable]
public class Address : EntityDefault
{
        public Address()
        {
            People = new HashSet<Person>();
        }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? NeighborHud { get; set; }

        // Relacionamento 
        // relacionamento municipio e residencia
        public Guid TownShiepId { get; set; }
        public TownShiep? GetTownShiep { get; set; }
        public Hospital? GetHospital { get; set; }
        public ICollection<Person> People { get; set; }
}