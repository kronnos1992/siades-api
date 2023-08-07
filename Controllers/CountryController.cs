using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.DTOs.BloodDTO;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryRepository repository;

        public CountryController(ILogger<CountryController> logger, ICountryRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewBlood([FromBody] CountryDTO entity)
        {
            try
            {
                await repository.NewCountry(entity);
                return Ok($"{entity.CountryName}, Adicionado com sucesso");
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
        public ActionResult<IEnumerable<Country>> GetAllAsync()
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
        public async Task<IActionResult> GetAsync(int id)
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
        public async Task<IActionResult> Update([FromBody] CountryDTO entity, int id)
        {
            try
            {
                await repository.Update(entity, id);
                return Ok($"{entity.CountryName}, Atualizado com sucesso");
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