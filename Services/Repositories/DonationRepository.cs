using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly SiadesDbContext? dbContext;

        public DonationRepository(SiadesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateDonation(int donorId)
        {
            var donor = await dbContext.Tb_Donor.SingleOrDefaultAsync(x => x.Id == donorId);
            if (donor.Id > 0)
            {
                donor.LastGivenDate = DateTime.Now;
                donor.NextGivenDate = DateTime.Now.AddDays(90);
                donor.RemaingDays = 90 - donor.NextGivenDate.Day;

                var donation = new Donation
                {
                    BloodGroup = donor.BloodGroupName,
                    CreatedAt = DateTime.Now,
                    Qty = 1,
                    DonorId = donor.Id,
                };

                var foundInStock = dbContext.Tb_StockHold
                    .SingleOrDefault(x => x.StockHoldId == donor.BloodGroupName);

                foundInStock.Qty += 1;

                dbContext.UpdateRange(donor, foundInStock);
                await dbContext.AddRangeAsync(donation);
                await dbContext.SaveChangesAsync();

            }
            else
            {
                return;
            }
        }

    }
}