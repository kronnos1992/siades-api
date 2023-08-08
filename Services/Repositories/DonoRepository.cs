using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.DTOs.DonorDTO;
using siades.Services.Interfaces;

namespace siades.Services.Repositories;

public class DonoRepository : IDonoRepository
{
    private readonly SiadesDbContext dbContext;

    public DonoRepository(SiadesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task Delete(int id)
    {
        try
        {
            var donor = await dbContext.Tb_Donor
            .FirstOrDefaultAsync(x => x.Id == id);
            if (donor.ToString().Trim().Length > 0)
            {
                dbContext.Remove(donor);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("", ex);
        }
    }

    public async Task<Donor> GetValue(int id)
    {
        try
        {
            var donor = await dbContext.Tb_Donor
                .FirstOrDefaultAsync(x => x.Id == id);

            if (donor.ToString().Trim().Length > 0)
            {
                return donor;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("", ex);
        }
    }

    public async Task<IEnumerable<Donor>> GetValues()
    {
        try
        {
            var donor = await dbContext.Tb_Donor
                .ToListAsync();

            if (donor.ToString().Trim().Length > 0)
            {
                return donor;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("", ex);
        }
    }

    public async Task NewDonor(DonorDTO entity, int bloodId, int townId)
    {
        try
        {
            var town = dbContext.Tb_TownShiep
                .SingleOrDefault(x => x.Id == townId);

            var blood = dbContext.Tb_Blood
                .SingleOrDefault(x => x.Id == bloodId);

            var donor = new Donor
            {

                RefNumber = string.Concat(new Random().Next(0, 99) + "/" + DateTime.Now.Year),
                CreatedAt = DateTime.Now,
                DonorType = entity.DonorType.Trim().ToUpper(),
                IsElegilbe = entity.IsElegilbe,
                BloodGroupName = blood.BloodGroupName,

                GetPerson = new Person
                {

                    CreatedAt = DateTime.Now,
                    FullName = entity.FullName.ToUpper(),
                    IdentDocNumber = entity.IdentDocNumber.Trim().ToUpper(),
                    TypeIdentNumber = entity.TypeIdentNumber.ToUpper(),
                    BirthDate = entity.BirthDate,
                    Age = DateTime.Now.Year - entity.BirthDate.Year,

                    GetAddress = new Address
                    {

                        CreatedAt = DateTime.Now,
                        Street = entity.Street.Trim().ToUpper(),
                        HouseNumber = entity.HouseNumber.Trim().ToUpper(),
                        NeighborHud = entity.NeighborHud.Trim().ToUpper(),
                        GetTownShiep = town
                    },

                    GetContact = new Contact
                    {

                        CreatedAt = DateTime.Now,
                        PhoneNumeber = entity.PhoneNumber,
                        EmailAdrress = entity.EmailAdrress,
                        HousePhoneNumber = entity.HousePhoneNumber,
                    },
                    GetBlood = blood,
                }

            };
            await dbContext.AddRangeAsync(donor);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Donor> Update(DonorDTO entity, int id)
    {
        try
        {
            var donor = await dbContext.Tb_Donor
                .FirstOrDefaultAsync(x => x.Id == id);

            if (donor.ToString().Length > 0)
            {
                donor.UpdatedAt = DateTime.Now;
                donor.GetPerson.CreatedAt = DateTime.Now;
                donor.GetPerson.GetContact.UpdatedAt = DateTime.Now;
                donor.GetPerson.GetAddress.UpdatedAt = DateTime.Now;
                donor.DonorType = entity.DonorType;
                donor.IsElegilbe = entity.IsElegilbe;


                donor.GetPerson.IdentDocNumber = entity.IdentDocNumber.Trim().ToUpper();
                donor.GetPerson.TypeIdentNumber = entity.TypeIdentNumber.Trim().ToUpper();
                donor.GetPerson.FullName = entity.FullName.Trim().ToUpper();
                donor.GetPerson.GetContact.PhoneNumeber = entity.PhoneNumber.Trim().ToUpper();
                donor.GetPerson.GetContact.HousePhoneNumber = entity.HousePhoneNumber.Trim().ToUpper();
                donor.GetPerson.GetContact.EmailAdrress = entity.EmailAdrress.Trim().ToUpper();
                donor.GetPerson.GetAddress.Street = entity.Street.Trim().ToUpper();
                donor.GetPerson.GetAddress.HouseNumber = entity.HouseNumber.Trim().ToUpper();
                donor.GetPerson.GetAddress.NeighborHud = entity.NeighborHud.Trim().ToUpper();

                dbContext.UpdateRange(donor);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Registro não encontrado");
            }
            return donor;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}