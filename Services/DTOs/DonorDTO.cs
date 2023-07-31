using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.DTOs.DonorDTO
{
    public class DonorDTO
    {
        public string? FullName { get; set; }
        public string? IdentDocNumber { get; set; }
        public string? TypeIdentNumber { get; set; }
        public string? RefNumber { get; set; }
        public string? DonorType { get; set; }
        public string? PhoneNumeber { get; set; }
        public string? EmailAdrress { get; set; }
        public string? HousePhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? NeighborHud { get; set; }
        public string? BirthStreet { get; set; }
        public string? BirthHouseNumber { get; set; }
        public string? BirthNeighborHud { get; set; }
    }
}