using siades.Default;

namespace siades.Models
{
    [Serializable]
    public class Donation : EntityDefault
    {
        public string BloodGroup { get; set; }
        public int Qty { get; set; }
        public int DonorId { get; set; }
        public Donor GetDonor { get; set; }

    }
}