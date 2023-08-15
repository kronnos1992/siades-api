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
    public class HospitalController : ControllerBase
    {
        private readonly ILogger<HospitalController> _logger;
        private readonly IHospitalRepository repository;

        public HospitalController(ILogger<HospitalController> logger, IHospitalRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Insert([FromBody] HospitalDTO entity, int townId)
        {
            try
            {
                await repository.NewHospital(entity, townId);
                return Ok($"Registro adicionado com sucesso, {entity.HospitalName}");
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
                var hospital = await repository.GetValues();
                if (hospital == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(hospital);
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
                var hospital = await repository.GetValue(id);
                if (hospital == null)
                {
                    return NotFound("Registro não encontrado");
                }
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody] HospitalDTO entity, int id)
        {
            try
            {
                await repository.Update(entity, id);
                return Ok("Regitro atualizado com sucesso");
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