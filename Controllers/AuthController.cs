using siades.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using siades.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(401)]
    [ProducesResponseType(201)]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;


        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [HttpPost("signup")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> SignUp([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = await authRepository.RegisterAsync(userDTO);
                if (!ModelState.IsValid)
                {
                    return BadRequest("Erro ao cadastrar novo usuario");
                }
                return CreatedAtAction("SignUp", $"Usuário {user.FullName} registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userDTO)
        {
            try
            {
                var login = await authRepository.LoginAsync(userDTO);
                if (!ModelState.IsValid)
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

        [HttpPost("createrole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO roleDTO)
        {
            try
            {
                var role = await authRepository.CreateRoleAsync(roleDTO.RoleName);
                if (!ModelState.IsValid)
                {
                    return BadRequest("Erro ao cadastrar o perfil!");
                }
                return CreatedAtAction("createrole", $"Perfil {roleDTO.RoleName} cadastrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            };
        }

        [HttpPost("signroletouser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SignRolesToUsers(string userId, string roleName)
        {
            try
            {
                var role = await authRepository.AssignRoleToUser(userId, roleName);
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Erro ao atribuir roles aos usuários! {ModelState.Values}");
                }
                return Created("", $"permissão {roleName} atribuida com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            };
        }
        [HttpGet("get-users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var user = await authRepository.GetUsers();
                if (ModelState.IsValid)
                {
                    return NotFound($"nenhum registro encontrado {ModelState.Values}");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro, por favor tente novamente {ex.Message}");
            };
        }

        [HttpGet("get-roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var user = await authRepository.GetRoles();
                if (ModelState.IsValid)
                {
                    return NotFound($"nenhum registro encontrado {ModelState.Values}");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro, por favor tente novamente {ex.Message}");
            };
        }
        [HttpDelete("delete-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await authRepository.DeleteUser(userId);
            if (user)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("delete-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await authRepository.DeleteRole(roleId);
            if (role)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpPut("update-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateteUser(string userId)
        {
            var user = await authRepository.UpdateteUser(userId);
            if (user)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpPut("update-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateteRole(string roleId)
        {
            var role = await authRepository.UpdateteRole(roleId);
            if (role)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}