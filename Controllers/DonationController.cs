using Microsoft.AspNetCore.Mvc;
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
            await donation.CreateDonation(donorId);
            return Ok("Doação Registrada");
        }
    }
}