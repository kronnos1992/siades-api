
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using siades.Services.DTOs;
using AuthenticationResult = siades.Services.DTOs.AuthenticationResult;

namespace siades.Services.Interfaces
{
    public interface IAuthRepository
    {
        public Task<UserDTO> GetUserAsync();
        public Task<UserDTO> RegisterAsync(UserDTO userDTO);
        public Task<IEnumerable<IdentityRole>> GetRoles();
        public Task<IEnumerable<IdentityUser>> GetUsers();
        public Task<AuthenticationResult> LoginAsync(UserLoginDTO userDTO);
        Task<string> CreateRoleAsync(string roleNameO);
        Task<string> AssignRoleToUser(string userId, string roleName);

    }
}