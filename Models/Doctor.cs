using siades.Default;

namespace siades.Models;
[Serializable]
public class Doctor : EntityDefault
{
    public string? DocNumber { get; set; }
    public Guid SpecialityId { get; set; }
    public Guid PersonId { get; set; }
    public Person? GetPerson { get; set; }
    public Speciality? GetSpeciality { get; set; }
}