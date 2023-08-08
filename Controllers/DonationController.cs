using Microsoft.AspNetCore.Mvc;
using siades.Models;
using siades.Services.Interfaces;

namespace siades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationRepository donation;

        public DonationController(IDonationRepository donation)
        {
            this.donation = donation;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateDonation(int donorId)
        {
            try
            {
                await donation.CreateDonation(donorId);
                return Ok("Doação Registrada");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Donation>> List()
        {
            try
            {
                var _donation = donation.List();
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("getone")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> List(int id)
        {
            try
            {
                var _donation = await donation.List(id);
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("groupname")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> List(string name)
        {
            try
            {
                var _donation = await donation.List(name);
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("donor")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> ListByDonor(int donorId)
        {
            try
            {
                var _donation = await donation.ListByDonor(donorId);
                return Ok(_donation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}