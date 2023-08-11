
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using siades.Models.IdentityModels;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly IMapper mapper;
        private readonly RoleManager<Roles> roleManager;

        public AuthRepository( 
            IConfiguration configuration, 
            UserManager<Users> userManager, 
            SignInManager<Users> signInManager,
            RoleManager<Roles> roleManager, 
            IMapper mapper
        )
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        /* public async Task<bool> AssignRoleToUser(string userId, string roleName)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return false;
                }

                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    return false;
                }

                var result = await userManager.AddToRoleAsync(user, roleName);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<RoleDTO> CreateRole(RoleDTO roleDTO)
        {
           try
            {
                var role = mapper.Map<Roles>(roleDTO);
                var roleMaped = await roleManager.CreateAsync(role);
                var output = mapper.Map<RoleDTO>(role);

                if (roleMaped.Succeeded)
                {
                    return output;
                }
                throw new Exception($"{roleMaped.Errors}");            
            }
            catch (System.Exception ex)
            {
                throw new Exception("", ex);
            }
        }
 */
        public async Task<UserDTO> GetUserAsync(UserDTO userDTO)
        {
            return userDTO;
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
                        User = returnLogin
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
                throw new Exception("", ex);
            }
        }

        public async Task<UserDTO> RegisterAsync( UserDTO userDTO)
        {
            try
            {
                var user = mapper.Map<Users>(userDTO);
                var userMaped = await userManager.CreateAsync(user, userDTO.Password);
                var output = mapper.Map<UserDTO>(user);

                if (userMaped.Succeeded)
                {
                    return output;
                }
                throw new Exception($"{userMaped.Errors}");            
            }
            catch (System.Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        private async Task<string> GenerateToken(Users? user)
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

            
    }
}