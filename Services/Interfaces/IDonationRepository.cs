using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.Interfaces
{
    public interface IDonationRepository
    {
        Task CreateDonation(int id);
    }
}