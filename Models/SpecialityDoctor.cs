using siades.Default;

namespace siades.Models
{
    public class SpecialityDoctor : EntityDefault
    {
        public int DoctorId { get; set; }
        public int SpecialityId { get; set; }
        public Doctor GetDoctor { get; set; }
        public Speciality GetSpeciality { get; set; }
    }
}