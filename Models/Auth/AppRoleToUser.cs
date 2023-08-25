using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace siades.Models.Auth
{
    public class AppRoleToUser : IdentityUserRole<int>
    {
        public override int UserId { get; set; }
        public override int RoleId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}