using siades.Default;

namespace siades.Models
{
    public class SpecialityDoctor : EntityDefault
    {
        public Doctor? GetDoctor { get; set; }
        public Speciality? GetSpeciality { get; set; }
        public Guid DoctorId { get; set; }
        public Guid SpecialityId { get; set; }
    }
}