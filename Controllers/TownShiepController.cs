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
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddTownShiep([FromBody] TownShiepDTO entity, int provinceId)
        {
            try
            {
                await repository.NewTownShiep(entity, provinceId);
                return Ok($"{entity.Name} adicionado com sucesso");
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
                var TownShiep = await repository.GetValues();
                if (TownShiep == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(TownShiep);
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
                var TownShiep = await repository.GetValue(id);
                if (TownShiep == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(TownShiep);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody] TownShiepDTO entity, int id)
        {
            try
            {
                await repository.Update(entity, id);
                return Ok("registro atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(400)]
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