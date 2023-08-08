using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using siades.Models;

namespace siades.Services.Interfaces
{
    public interface IDonationRepository
    {
        Task<string> CreateDonation(int id);
        Task<Donation> List(int id);
        Task<IEnumerable<Donation>> List();
        Task<IEnumerable<Donation>> List(string donor);
        public Task<IEnumerable<Donation>> ListByDonor(int donorId);
        Task<string> Delete(int id);
    }
}