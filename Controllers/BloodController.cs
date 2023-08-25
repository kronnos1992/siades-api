using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin, Tecnico")]
public class BloodController : ControllerBase
{
    private readonly ILogger<BloodController> _logger;
    private readonly IBloodRepository repository;

    public BloodController(ILogger<BloodController> logger, IBloodRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> AddNewBlood([FromBody] BloodDTo entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await repository.NewBlood(entity);
                return Created("", "REgistro inserido com sucesso.");
            }
            return BadRequest("Houve erro no cadastro, por favor tente novamente ");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno, {ex.Message}");
        }
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var blood = await repository.GetValues();
            if (blood == null || blood.ToArray().Length < 0)
            {
                return NotFound($"Nenhum registro encontrado");
            }
            return Ok(blood);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro, por favor tente novamente {ex.Message}");
        }
    }

    [HttpGet]
    [Route("getone")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetAsync(int id)
    {
        try
        {
            var blood = await repository.GetValue(id);
            if (blood == null)
            {
                return NotFound($"Grupo sanguineo {blood} não encontrado");
            }
            return Ok(blood);
        }
        catch (Exception ex)
        {
            return BadRequest($"Houve erro no cadastro, por favor tente novamente {ex.Message}");
        }
    }

    [HttpPut]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Update([FromBody] BloodDTo entity, int id)
    {
        try
        {
            await repository.Update(entity, id);
            return Ok($"Grupo: {entity.Name} atualizado");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro, por favor tente novamente {ex.Message}");
        }
    }

    [HttpDelete]
    [ProducesResponseType(404)]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await repository.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro, por favor tente novamente {ex.Message}");
        }
    }

}
