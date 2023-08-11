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

        [HttpGet("getuser")]
        public async Task<IActionResult> GetUSer(UserDTO userDTO)
        {
            await authRepository.GetUserAsync(userDTO);
            return Ok();
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(UserDTO userDTO)
        {
            try
            {
                var user = await authRepository.RegisterAsync(userDTO);
                return Created("api/auth/signup", userDTO);
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
    
    }
}