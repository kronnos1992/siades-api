using siades.Default;

namespace siades.Models;
[Serializable]
public class Contact : EntityDefault
{

    public string? PhoneNumeber { get; set; }
    public string? EmailAdrress { get; set; }
    public string? HousePhoneNumber { get; set; }
    public Person? GetPerson { get; set; }
    
}