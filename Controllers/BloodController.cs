using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Controllers;

[ApiController]
[Route("api/[controller]")]
[Serializable]
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
    public async Task<IActionResult> AddNewBlood([FromBody] BloodDTo entity)
    {
        try
        {
            await repository.NewBlood(entity);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public ActionResult<IEnumerable<Blood>> GetAllAsync()
    {
        var blood = repository.GetValues();
        if (blood == null)
        {
            return NotFound();
        }
        return Ok(blood);
    }
    
    [HttpGet]
    [Route("getone")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        try
        {
            var blood = await repository.GetValue(id);
            if (blood == null)
            {
                return NotFound();
            }
            return Ok(blood);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(404)]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Update([FromBody] BloodDTo entity, Guid id)
    {
        try
        {
            await repository.Update(entity, id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [ProducesResponseType(404)]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Delete( Guid id)
    {
        try
        {
            await repository.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
