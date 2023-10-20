using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [AllowAnonymous]
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
        [ProducesResponseType(401)]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddNewCounty([FromBody] CountryDTO entity)
        {
            try
            {
                await repository.NewCountry(entity);
                if (ModelState.IsValid)
                {
                    return CreatedAtAction("AddNewCounty", $"{entity.CountryName} Adicionado com sucesso");
                }
                return BadRequest($"Erro, por favor tente novamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro de servidor, {ex.Message}");
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var County = await repository.GetValues();
                if (County == null)
                {
                    return NotFound();
                }
                return Ok(County);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpGet]
        [Route("getone")]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var County = await repository.GetValue(id);
                if (County == null)
                {
                    return NotFound();
                }
                return Ok(County);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody] CountryDTO entity, int id)
        {
            try
            {
                await repository.Update(entity, id);
                return Ok($"{entity.CountryName}, Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
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
}