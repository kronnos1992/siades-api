using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace siades.Models.Auth
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }

        public List<AppRoleToUser> Roles { get; set; }
    }
}