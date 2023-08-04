using siades.Default;

namespace siades.Models;
[Serializable]
public class Hospital : EntityDefault
{
    public string? HospitalName { get; set; }
    public Guid AddressId { get; set; }

    public Address? GetAddress { get; set; }
    public List<BloodRequest>? ListRequest { get; set; }
}