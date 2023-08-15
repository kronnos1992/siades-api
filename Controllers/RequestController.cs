using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddNewRequest([FromBody] RequestDTO entity, int bloodId, int hospitalId, int donorId)
        {
            try
            {
                await repository.CreateRequest(entity, donorId, hospitalId, bloodId);
                return Ok($"{entity} registrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
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
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
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
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AproveRequest(int id)
        {
            try
            {
                var request = repository.AproveRequest(id);
                if (request == null)
                {
                    return NotFound($"Pedido nº {id} não existe");
                }
                await Task.CompletedTask;
                return Ok($"Pedido nº {id} aprovado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }
    }
}