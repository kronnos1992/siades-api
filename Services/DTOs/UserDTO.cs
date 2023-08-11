using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.DTOs
{
    public partial class UserDTO
    {
        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(4)]
        public string? Password { get; set; }

        //[Required]
        //[MaxLength(200)]
        //public string? FullName { get; set; }
    }
}