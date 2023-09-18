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
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IDoctoRepository repository;

        public DoctorController(ILogger<DoctorController> logger, IDoctoRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddDoctor([FromForm] DoctorDTO entity, int bloodId, int townId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.NewDoctor(entity, bloodId, townId);
                    return Ok($"{entity.FullName} adicionado com sucesso");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPost]
        [Route("add-speciality")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> NewDoctorSpeciality(int doctorId, int specialityId)
        {
            try
            {
                await repository.LinkDocSpeciality(doctorId, specialityId);
                return Ok($"Registro atualizado com sucesso.");
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
                var doctor = await repository.GetValues();
                if (doctor == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(doctor);
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
                var doctor = await repository.GetValue(id);
                if (doctor == null)
                {
                    return NotFound("Registro não encontrado");
                }
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody] DoctorDTO entity, int id)
        {
            try
            {
                await repository.Update(entity, id);
                return Ok($"Registro atualizado com sucesso.");
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