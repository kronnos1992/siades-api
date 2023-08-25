
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using siades.Models.Auth;
using siades.Services.DTOs;
using siades.Services.Interfaces;
using AuthenticationResult = siades.Services.DTOs.AuthenticationResult;

namespace siades.Services.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> roleManager;

        public AuthRepository(
            IConfiguration configuration,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IMapper mapper
        )
        {

            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        public async Task<string> CreateRoleAsync(string roleName)
        {
            try
            {
                var role = await roleManager.CreateAsync(new AppRole(roleName));
                if (role.Succeeded)
                {
                    return role.Succeeded.ToString();
                }
                else
                {
                    return role.Errors.ToString();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<string> AssignRoleToUser(string userId, string roleName)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user == null || user.UserName.ToString().IsNullOrEmpty())
                {
                    return "nenhum usuario encontrado";
                }

                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    return "role não encontrada";
                }

                var result = await userManager.AddToRoleAsync(user, roleName);
                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de banco de dados", ex);
            }
        }

        public async Task<UserDTO> GetUserAsync()
        {
            try
            {
                var user = await userManager.Users.ToListAsync();
                var userD = mapper.Map<UserDTO>(user);
                return userD;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro de banco de dados", ex);
            }
        }
        public async Task<AuthenticationResult> LoginAsync(UserLoginDTO userDTO)
        {
            try
            {
                var user = await userManager.FindByNameAsync(userDTO.Username) ?? throw new Exception("Usuário não encontrado.");
                
                var output = await signInManager.CheckPasswordSignInAsync(user, userDTO.Password, false);
                if (output.Succeeded)
                {
                    var returnLogin = mapper.Map<UserLoginDTO>(user);

                    var token = await GenerateToken(user);

                    return new AuthenticationResult
                    {
                        Success = true,
                        Token = token,
                        SuccessMessage = "Login efeituado com sucesso!"
                    };
                } 
                else
                {
                    return new AuthenticationResult
                    {
                        Success = false,
                        ErrorMessage = "Nome de usuário ou senha incorretos."
                    };
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro de servidor, consulte o administrador para melhor esclarecimento", ex);
            }
        }

        public async Task<UserDTO> RegisterAsync( UserDTO userDTO)
        {
            try
            {
                var user = mapper.Map<AppUser>(userDTO);
                var userMaped = await userManager.CreateAsync(user, userDTO.Password);
                var output = mapper.Map<UserDTO>(user);

                if (userMaped.Succeeded)
                {
                    return output;
                }
                throw new Exception($"{userMaped.Errors}");            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<string> GenerateToken(AppUser user)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<IEnumerable<AppRole>> GetRoles()
        {
            var roles = await roleManager.Roles.ToListAsync()
                ?? throw new Exception("nenhum registro encontrado. ");
            return roles;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            try
            {
                var users = await userManager.Users.ToListAsync()
                    ?? throw new Exception("nenhum registro encontrado. ");
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro de banco de dados", ex);
            }
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await userManager.FindByNameAsync(userId);
            if (user == null)
            {
                return false;
            }
            await userManager.DeleteAsync(user);
            return true;
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            var role = await roleManager.FindByNameAsync(roleId);
            if (role == null)
            {
                return false;
            }
            await roleManager.DeleteAsync(role);
            return true;
        }

        public async Task<bool> UpdateteUser(string userId)
        {
            var user = await userManager.FindByNameAsync(userId);
            if (user == null)
            {
                return false;
            }
            await userManager.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdateteRole(string roleId)
        {
            var role = await roleManager.FindByNameAsync(roleId);
            if (role == null)
            {
                return false;
            }
            await roleManager.UpdateAsync(role);
            return true;
        }
    }
}