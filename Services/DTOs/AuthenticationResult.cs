using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using siades.Services.DTOs;

namespace siades.Services.DTOs
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public UserLoginDTO? User { get; set; }
        public string? ErrorMessage { get; set; }
    }
}