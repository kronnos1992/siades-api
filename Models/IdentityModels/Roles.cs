using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace siades.Models.IdentityModels
{
    public class Roles : IdentityRole<int>
    {
        public Roles()
        {
            Users = new HashSet<UserRoles>();
        }
        public IEnumerable<UserRoles> Users { get; set; }
    }
}