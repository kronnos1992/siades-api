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
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewDoctor([FromBody] DoctorDTO entity, int bloodId, int townId)
        {
            try
            {
                await repository.NewDoctor(entity, bloodId, townId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-speciality")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddNewDoctorSpeciality(int doctorId, int specialityId)
        {
            try
            {
                var data = repository.LinkDocSpeciality(doctorId, specialityId);
                await Task.CompletedTask;
                return Ok(data);
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
        public ActionResult<IEnumerable<Doctor>> GetAllAsync()
        {
            var doctor = repository.GetValues();
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpGet]
        [Route("getone")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var doctor = await repository.GetValue(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Update([FromBody] DoctorDTO entity, int id)
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