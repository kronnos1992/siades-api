using siades.Default;

namespace siades.Models;
[Serializable]
public class Donor : EntityDefault
{
    public string? RefNumber { get; set; }
    public string? DonorType { get; set; }
    public string? FirstGivenDate { get; set; }
    public string? LastGivenDate { get; set; }
    public string? NextGivenDate { get; set; }
    public int RemaingDays { get; set; }
    public Guid PersonId { get; set; } 
    public Person? GetPerson { get; set; }
    public bool? IsElegilbe { get; set; }
    public List<Donation>? Donations { get; set; }
}