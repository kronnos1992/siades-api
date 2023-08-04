using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.DTOs.DonorDTO
{
    public class DonorDTO
    {
        //donor
        public int RemaingDays { get; set; }
        public string? DonorType { get; set; }
        public string? FirstGivenDate { get; set; }
        public DateTime LastGivenDate { get; set; }
        public DateTime NextGivenDate { get; set; }
        public bool IsElegilbe { get; set; }
        public string? RefNumber { get; set; }

        // Person
        public string? FullName { get; set; }
        public string? IdentDocNumber { get; set; }
        public string? TypeIdentNumber { get; set; }

        // contact
        public string? PhoneNumber { get; set; }
        public string? EmailAdrress { get; set; }
        public string? HousePhoneNumber { get; set; }

        //address
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? NeighborHud { get; set; }


    }
}