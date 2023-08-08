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
    public DateTime BirthDate { get; set; }
    public int Age { get; set; }

    //relacionamentos
    public Contact? GetContact { get; set; }
    public Address? GetAddress { get; set; }
    //public BirthAddress? GetBirthAddress { get; set; }
    public Blood? GetBlood { get; set; }

    public ICollection<Doctor> DoctorsList { get; set; }
    public ICollection<Donor> DonorsList { get; set; }
    //public List<Contact>? ContactList {get; set;}  
}