using siades.Default;

namespace siades.Models;
[Serializable]
public class Country : EntityDefault
{
    public Country()
    {
        ProvinceList = new HashSet<Province>();
    }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }

    // List of provinces
    public readonly ICollection<Province> ProvinceList;
}