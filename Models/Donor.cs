using siades.Default;

namespace siades.Models;
[Serializable]
public class Donor : EntityDefault
{
    public string? RefNumber { get; set; }
    public string? BloodGroupName { get; set; }
    public string? DonorType { get; set; }
    public DateTime LastGivenDate { get; set; }
    public DateTime NextGivenDate { get; set; }
    public int RemaingDays { get; set; }
    public bool? IsElegilbe { get; set; }
    public Person? GetPerson { get; set; }
    public List<Donation>? Donations { get; set; }
}