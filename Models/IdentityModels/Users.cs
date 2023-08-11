using Microsoft.AspNetCore.Identity;

namespace siades.Models.IdentityModels
{
    public class Users : IdentityUser<int>
    {
        public Users()
        {
            Roles = new HashSet<UserRoles>();
        }
        public IEnumerable<UserRoles>? Roles { get; set; }
    }
}