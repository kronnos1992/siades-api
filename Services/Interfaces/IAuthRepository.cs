using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using siades.Models.IdentityModels;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IAuthRepository
    {
        public Task<UserDTO> GetUserAsync(UserDTO userDTO);
        public Task<UserDTO> RegisterAsync(UserDTO userDTO);
        public Task<AuthenticationResult> LoginAsync(UserLoginDTO userDTO);
        // Task<RoleDTO> CreateRole(RoleDTO roleDTO);
        // Task<bool> AssignRoleToUser(string userId, string roleName);
    }
}