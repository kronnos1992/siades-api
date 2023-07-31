using siades.Default;

namespace siades.Models
{
    [Serializable]
    public class HospitalService : EntityDefault
    {
        public string? ServiceName { get; set; }
        public List<RelHospService>? Hospitals { get; set; }
    }
}