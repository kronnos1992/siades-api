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
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;
        private readonly IRequestRepository repository;

        public RequestController(ILogger<RequestController> logger, IRequestRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewRequest([FromBody] RequestDTO entity, int bloodId, int hospitalId, int donorId)
        {
            try
            {
                await repository.CreateRequest(entity, donorId, hospitalId, bloodId);
                return Created("", $"{entity}");
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
        public ActionResult<IEnumerable<BloodRequest>> GetAllAsync()
        {
            var blood = repository.ShowRequests();
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
                var blood = await repository.ShowRequest(id);
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
        public async Task<IActionResult> Update([FromBody] RequestDTO entity, int id)
        {
            try
            {
                await repository.UpdateRequest(entity, id);
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
                await repository.DeleteRequest(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("aprove")]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AproveRequest(int id)
        {
            await repository.AproveRequest(id);
            return NoContent();
        }
    }
}