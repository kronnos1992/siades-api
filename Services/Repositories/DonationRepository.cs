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
        private string message;

        public DonationRepository(SiadesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string> CreateDonation(int donorId)
        {
            try
            {
                var donor = await dbContext.Tb_Donor.SingleOrDefaultAsync(x => x.Id == donorId);
                var person = await dbContext.Tb_Person.SingleOrDefaultAsync(x => x.Id == donor.Id);
                if (donor.Id > 0)
                {
                    if (person.Age >= 18)
                    {
                        if (donor.IsElegilbe == true)
                        {
                            donor.LastGivenDate = DateTime.Now;
                            donor.NextGivenDate = DateTime.Now.AddMonths(3);
                            donor.RemaingDays = donor.NextGivenDate.Day - DateTime.Now.Day;


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

                            await dbContext.AddRangeAsync(donation);
                            dbContext.UpdateRange(donor, foundInStock);
                            await dbContext.SaveChangesAsync();
                            return message = "doação registrada com sucesso!";
                        }
                        else
                        {
                            return message = "Doador não aprovado para doação. ";
                        }
                    }
                    else
                    {
                        return message = "Doador menor de idade, não pode doar.";
                    }
                }
                else
                {
                    return message = "Doador não encontrado.";
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var donation = dbContext.Tb_Donation.SingleOrDefaultAsync(x => x.Id == id);
                if (donation != null)
                {
                    dbContext.Remove(donation);
                    return message = $"Doação eliminada com sucesso";
                }
                return message = "doação não encontrada. ";

            }
            catch (Exception)
            {
                throw new Exception(message);
            }
        }

        public async Task<Donation> List(int id)
        {
            try
            {
                var donation = await dbContext.Tb_Donation.SingleOrDefaultAsync(x => x.Id == id);
                if (donation != null)
                {
                    return donation;
                }
                throw new NullReferenceException("Nenhum registro encontrado");

            }
            catch (Exception)
            {
                throw new Exception(message);
            }
        }

        public async Task<IEnumerable<Donation>> List()
        {
            try
            {
                var donation = await dbContext.Tb_Donation.ToListAsync();
                if (donation != null)
                {
                    return donation;
                }
                throw new NullReferenceException("Doação não encontrada. ");
            }
            catch (Exception)
            {
                throw new Exception(message);
            }
        }

        public async Task<IEnumerable<Donation>> List(string blood)
        {
            try
            {
                var donation = await dbContext.Tb_Donation
                    .Where(x => x.BloodGroup.Contains(blood))
                    .ToListAsync();
                if (donation != null)
                {
                    return donation;
                }
                throw new NullReferenceException("Doação não encontrada. ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<Donation>> ListByDonor(int donorId)
        {
            try
            {
                var donation = await dbContext.Tb_Donation
                    .Where(x => x.DonorId == donorId)
                    .ToListAsync();
                if (donation != null)
                {
                    return donation;
                }
                throw new NullReferenceException("Registro não encontrada. ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}