using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(200)]
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
        public async Task<IActionResult> AddNewRequest([FromBody] RequestDTO entity, int bloodId, int hospitalId, int donorId)
        {
            try
            {
                await repository.CreateRequest(entity, donorId, hospitalId, bloodId);
                return CreatedAtAction("AddNewRequest", "Pedido registrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var blood = await repository.ShowRequests();
                if (blood == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(blood);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpGet]
        [Route("getone")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var blood = await repository.ShowRequest(id);
                if (blood == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(blood);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RequestDTO entity, int id)
        {
            try
            {
                await repository.UpdateRequest(entity, id);
                return Ok("Registro atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repository.DeleteRequest(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpPut]
        [Route("aprove")]
        public async Task<IActionResult> AproveRequest(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound($"Pedido nº {id} não existe");
                }
                await repository.AproveRequest(id);
                return Ok($"Pedido nº {id} aprovado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, {ex.Message}");
            }
        }
    }
}