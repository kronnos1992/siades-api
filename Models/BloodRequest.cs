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
        public int Qty { get; set; }
        public string? BloodGroup { get; set; }
        public Donor? GetDonor { get; set; }
        public Hospital? GetHospital { get; set; }
        public Blood? GetBlood { get; set; }

    }
}