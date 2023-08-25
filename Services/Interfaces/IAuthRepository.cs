
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using siades.Models.Auth;
using siades.Services.DTOs;
using AuthenticationResult = siades.Services.DTOs.AuthenticationResult;

namespace siades.Services.Interfaces
{
    public interface IAuthRepository
    {
        public Task<UserDTO> GetUserAsync();
        public Task<UserDTO> RegisterAsync(UserDTO userDTO);
        public Task<IEnumerable<AppRole>> GetRoles();
        public Task<IEnumerable<AppUser>> GetUsers();
        public Task<AuthenticationResult> LoginAsync(UserLoginDTO userDTO);
        Task<string> CreateRoleAsync(string roleName);
        Task<string> AssignRoleToUser(string userId, string roleName);
        Task<bool> DeleteUser(string userId);
        Task<bool> DeleteRole(string roleId);
        Task<bool> UpdateteUser(string userId);
        Task<bool> UpdateteRole(string roleId);

    }
}