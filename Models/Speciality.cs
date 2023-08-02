using siades.Default;

namespace siades.Models
{
    public class Speciality : EntityDefault
    {
        public string? SpecialityName { get; set; }
        public List<SpecialityDoctor>? Doctors { get; set; }
    }
}