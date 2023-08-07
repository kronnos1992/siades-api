using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : ControllerBase
    {
    private readonly ILogger<ProvinceController> _logger;
    private readonly IProvinceRepository repository;

    public ProvinceController(ILogger<ProvinceController> logger, IProvinceRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewProvince([FromBody] ProvinceDTO entity, int countryId)
        {
        try
        {
            await repository.NewProvince(entity, countryId);
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
    public ActionResult<IEnumerable<Province>> GetAllAsync()
    {
        var Province = repository.GetValues();
        if (Province == null)
        {
            return NotFound();
        }
        return Ok(Province);
    }
    
    [HttpGet]
    [Route("getone")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
        public async Task<IActionResult> GetAsync(int id)
        {
        try
        {
            var Province = await repository.GetValue(id);
            if (Province == null)
            {
                return NotFound();
            }
            return Ok(Province);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(404)]
    [ProducesResponseType(201)]
        public async Task<IActionResult> Update([FromBody] ProvinceDTO entity, int id)
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
        public async Task<IActionResult> Delete(int id)
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
}