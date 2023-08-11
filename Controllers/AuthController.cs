using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using siades.Models.IdentityModels;
using siades.Services.DTOs;
using siades.Services.Interfaces;

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

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUSer(UserDTO userDTO)
        {
            await authRepository.GetUserAsync(userDTO);
            return Ok();
        }

        [HttpPost("SignUp")]
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
        [HttpGet("Login")]
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