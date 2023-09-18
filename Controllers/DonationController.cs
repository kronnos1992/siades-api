using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationRepository donation;

        public DonationController(IDonationRepository donation)
        {
            this.donation = donation;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDonation(int donorId)
        {
            try
            {
                await donation.CreateDonation(donorId);
                return CreatedAtAction("CreateDonation", "Doação Registrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]

        public async Task<IActionResult> List()
        {
            try
            {
                var _donation = await donation.List();
                if (_donation == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }
        [HttpGet("stock")]

        public async Task<IActionResult> ViewStock()
        {
            try
            {
                var _donation = await donation.VieStock();
                if (_donation == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }
        [HttpGet]
        [Route("getone")]

        public async Task<IActionResult> List(int id)
        {
            try
            {
                var _donation = await donation.List(id);
                if (_donation == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }
        [HttpGet]
        [Route("groupname")]

        public async Task<IActionResult> List(string name)
        {
            try
            {
                var _donation = await donation.List(name);
                if (_donation == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }

        [HttpGet]
        [Route("donor")]

        public async Task<IActionResult> ListByDonor(int donorId)
        {
            try
            {
                var _donation = await donation.ListByDonor(donorId);
                if (_donation == null)
                {
                    return NotFound("Nenhum registro encontrado");
                }
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int donorId)
        {
            try
            {
                await donation.Delete(donorId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro, por favor tente novamente {ex.Message}");
            }
        }
    }
}