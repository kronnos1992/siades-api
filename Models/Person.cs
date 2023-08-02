using siades.Default;
namespace siades.Models;
[Serializable]
public class Person : EntityDefault
{
    public Person()
    {
        DoctorsList = new HashSet<Doctor>();
        DonorsList = new HashSet<Donor>();
    }
    public string? FullName { get; set; }
    public string? IdentDocNumber { get; set; }
    public string? TypeIdentNumber { get; set; }
   
    
    //chaves estrangeiras
    public Guid AddressId { get; set; }
    public Guid BirthAddressId { get; set; }
    public Guid ContactId { get; set; }
    public Guid BloodId { get; set; }
    public string? BirthAddress { get; set; }
    
    //relacionamentos
    public Contact? GetContact { get; set; }
    public Address? GetAddress { get; set; }
    //public BirthAddress? GetBirthAddress { get; set; }
    public Blood? GetBlood { get; set; }

    public ICollection<Doctor> DoctorsList { get; set; }
    public ICollection<Donor> DonorsList { get; set; } 
    //public List<Contact>? ContactList {get; set;}  
}