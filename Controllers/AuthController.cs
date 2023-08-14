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
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(UserDTO userDTO)
        {
            try
            {
                var user = await authRepository.RegisterAsync(userDTO);
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            try
            {
                var login =await authRepository.LoginAsync(userDTO);
                if (login == null)
                {
                    return Unauthorized();
                }
                return Ok(login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            };
        }
        
        [HttpPost("role")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRoleAsync(string name)
        {
            try
            {
                var role =await authRepository.CreateRoleAsync(name);
                if (role == null)
                {
                    return Unauthorized();
                }
                return Created("",role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            };
        }
        [HttpPost("roleusers")]
        [AllowAnonymous]
        public async Task<IActionResult> SignRolesToUsers(string value1, string value2)
        {
            try
            {
                var role =await authRepository.AssignRoleToUser(value1,value2);
                if (role == null)
                {
                    return Unauthorized();
                }
                return Created("",role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            };
        }
    
    }
}