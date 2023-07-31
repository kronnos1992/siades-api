using siades.Default;

namespace siades.Models
{
    public class RelHospService : EntityDefault
    {
        public Guid HospitalServiceId { get; set; }
        public Guid HospitalId { get; set; }
        public Hospital? GetHospital { get; set; }
        public HospitalService? GetService { get; set; }
        
    }
}