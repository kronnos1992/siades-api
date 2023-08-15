using siades.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using siades.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [HttpPost("signup")]
        //[Authorize(Roles ="Admin")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> SignUp(UserDTO userDTO)
        {
            try
            {
                var user = await authRepository.RegisterAsync(userDTO);
                if (user == null)
                {
                    return Unauthorized();
                }
                return Ok($"Usuario {user} adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve erro no cadastro, por favor tente novamente {ex.Message}");
            }
        }
        [HttpPost("login")]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            try
            {
                var login =await authRepository.LoginAsync(userDTO);
                if (login == null)
                {
                    return NotFound($"Usuario {userDTO}, não encontrado. ");
                }
                return Ok(login);
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve erro ao fazer login, por favor tente novamente {ex.Message}");
            };
        }
        
        [HttpPost("role")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateRoleAsync(string name)
        {
            try
            {
                var role =await authRepository.CreateRoleAsync(name);
                if (role == null)
                {
                    return Unauthorized();
                }
                return Ok($"Role {role} adicionada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            };
        }
        [HttpPost("roleusers")]
        //[Authorize(Roles ="Admin")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> SignRolesToUsers(string userId, string roleName)
        {
            try
            {
                var role =await authRepository.AssignRoleToUser(userId,roleName);
                if (role == null)
                {
                    return Unauthorized();
                }
                return Ok($"permissão {roleName} atribuida com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro, por favor tente novamente {ex.Message}");
            };
        }
    
    }
}