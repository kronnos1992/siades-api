using siades.Default;

namespace siades.Models
{
    [Serializable]
    public class BloodRequest : EntityDefault
    {
        public bool IsAcepted { get; set; } = false;
        public string? DiseasedName { get; set; }
        public bool IsHomeDonor { get; set; } = false;
        public bool HasFamDonor { get; set; } = false;
        public int DiseasedAge { get; set; }
        public Guid BloodDescriptionId { get; set; }
        public Guid HospitalId { get; set; }
        public Guid DonorId { get; set; }
        public Donor? GetDonor { get; set; }
        public Hospital? GetHospital { get; set; }
        public Blood? GetBlood { get; set; }
        
    }
}