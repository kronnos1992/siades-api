using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.DTOs.DonorDTO;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly ILogger<DonorController> _logger;
        private readonly IDonoRepository repository;

        public DonorController(ILogger<DonorController> logger, IDonoRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddNewDonor([FromForm] DonorDTO entity, int bloodId, int townId)
        {
            try
            {
                await repository.NewDonor(entity, bloodId, townId);
                return Ok($"Dador {entity.FullName}, inserido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
               var donor = await repository.GetValues();
                if (donor == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(donor); 
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
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var donor = await repository.GetValue(id);
                if (donor == null)
                {
                    return NotFound($"dador não encontrado");
                }
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody] DonorDTO entity, int id)
        {
            try
            {
                await repository.Update(entity, id);
                return Ok("Registro atualizado ");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpDelete]
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