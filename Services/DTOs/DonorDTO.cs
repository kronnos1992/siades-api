using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.DTOs.DonorDTO
{
    public class DonorDTO
    {
        //donor

        public string DonorType { get; set; }
        public bool IsElegilbe { get; set; }

        // Person
        public string FullName { get; set; }
        public string IdentDocNumber { get; set; }
        public string TypeIdentNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string PlaceOfBirth { get; set; }
        //public int Age { get; set; }

        // contact
        public string PhoneNumber { get; set; }
        public string EmailAdrress { get; set; }
        public string HousePhoneNumber { get; set; }

        //address
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string NeighborHud { get; set; }


    }
}