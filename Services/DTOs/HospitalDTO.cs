using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.DTOs
{
    public class HospitalDTO
    {
        public string HospitalName { get; set; }
        //address
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string NeighborHud { get; set; }
    }
}