using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.DTOs
{
    public class RequestDTO
    {
        public bool IsAcepted { get; set; } = false;
        public string? DiseasedName { get; set; }
        public bool IsHomeDonor { get; set; } = false;
        public bool HasFamDonor { get; set; } = false;
        public int Qty { get; set; }
        public int DiseasedAge { get; set; }
    }
}