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
    public class TownShiepController : ControllerBase
    {

        private readonly ILogger<TownShiepController> _logger;
        private readonly ITownshiepRepository repository;

        public TownShiepController(ILogger<TownShiepController> logger, ITownshiepRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewTownShiep([FromBody] TownShiepDTO entity, Guid provinceId)
        {
            try
            {
                await repository.NewTownShiep(entity, provinceId);
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
        public ActionResult<IEnumerable<TownShiep>> GetAllAsync()
        {
            var TownShiep = repository.GetValues();
            if (TownShiep == null)
            {
                return NotFound();
            }
            return Ok(TownShiep);
        }
    
        [HttpGet]
        [Route("getone")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var TownShiep = await repository.GetValue(id);
                if (TownShiep == null)
                {
                    return NotFound();
                }
                return Ok(TownShiep);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Update([FromBody] TownShiepDTO entity, Guid id)
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
}