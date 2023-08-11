using Microsoft.AspNetCore.Identity;

namespace siades.Models.IdentityModels
{
    public class UserRoles : IdentityUserRole<int>
    {
        public Users? User { get; set; }
        public Roles? Role { get; set; }
    }
}