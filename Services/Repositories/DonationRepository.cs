using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly SiadesDbContext dbContext;
        private string message;

        public DonationRepository(SiadesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateDonation(int donorId)
        {
            try
            {
                var donor = await dbContext.Tb_Donor
                    .Include(x => x.GetPerson)
                    .SingleOrDefaultAsync(x => x.Id == donorId)
                        ?? throw new NullReferenceException("Dador não encontrado");
                var person = await dbContext.Tb_Person.FirstOrDefaultAsync(x => x.Id == donor.GetPerson.Id);

                var foundInStock = dbContext.Tb_StockHold
                    .SingleOrDefault(x => x.StockHoldId == donor.BloodGroupName);

                var donation = new Donation
                {
                    BloodGroup = donor.BloodGroupName,
                    CreatedAt = DateTime.Now,
                    Qty = 1,
                    DonorId = donor.Id,
                };
                foundInStock.Qty += 1;

                // local estática
                TimeSpan remainingTime = donor.NextGivenDate - DateTime.Now;
                donor.LastGivenDate = DateTime.Now;
                donor.NextGivenDate = DateTime.Now.AddDays(90);
                donor.RemaingDays = remainingTime.Days;


                if (person.Age < 18)
                    throw new Exception("Dador menor de idade, não pode doar.");

                if (!donor.IsElegilbe)
                    throw new Exception("Dador não habilitado a doar, rever o estado clínico do dador.");

                if (donor.RemaingDays > 0)
                    throw new Exception($"Ainda faltam {donor.RemaingDays} para a próxima doação. ");

                //persistencia
                await dbContext.AddAsync(donation);
                dbContext.UpdateRange(donor, foundInStock);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var donation = await dbContext.Tb_Donation.SingleOrDefaultAsync(x => x.Id == id);
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
        public async Task<IEnumerable<StockHold>> VieStock()
        {
            try
            {
                return await dbContext.Tb_StockHold.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro, {ex.Message}");
            }
        }


    }
}