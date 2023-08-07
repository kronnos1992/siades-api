using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialityController : ControllerBase
    {
        private readonly ILogger<SpecialityController> _logger;
        private readonly ISpecialityRepository repository;

        public SpecialityController(ILogger<SpecialityController> logger, ISpecialityRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewSpeciality([FromBody] SpecialityDTO entity)
        {
            try
            {
                await repository.NewSpeciality(entity);
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
        public ActionResult<IEnumerable<Speciality>> GetAllAsync()
        {
            var speciality = repository.GetValues();
            if (speciality == null)
            {
                return NotFound();
            }
            return Ok(speciality);
        }

        [HttpGet]
        [Route("getone")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var speciality = await repository.GetValue(id);
                if (speciality == null)
                {
                    return NotFound();
                }
                return Ok(speciality);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Update([FromBody] SpecialityDTO entity, int id)
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