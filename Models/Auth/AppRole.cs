using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace siades.Models.Auth
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole(string roleName) : base(roleName)
        {
            this.RoleName = roleName;
        }
        public string RoleName { get; set; }

        public List<AppRoleToUser> Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}