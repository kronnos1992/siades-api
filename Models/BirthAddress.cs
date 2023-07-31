using siades.Default;

namespace siades.Models;
[Serializable]
public class BirthAddress : EntityDefault
{
    public string? BirthStreet { get; set; }
    public string? BirthHouseNumber { get; set; }
    public string? BirthNeighborHud { get; set; }

    // relacionamento municipio e residencia
    public Guid TownShiepId { get; set; }

    public TownShiep? GetTownShiep { get; set; }
    public List<Person>? People { get; set; }

}