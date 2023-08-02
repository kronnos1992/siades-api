using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly SiadesDbContext dbcontext;

        public SpecialityRepository(SiadesDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task Delete(Guid id)
        {
            try
            {
                var speciality = await dbcontext.Tb_Speciality.FindAsync(id);
                dbcontext.RemoveRange(speciality);
                await dbcontext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }

        public async Task<Speciality> GetValue(Guid id)
        {
            try
            {
                var speciality = await dbcontext.Tb_Speciality.FirstOrDefaultAsync(x => x.Id == id);
                if (speciality == null)
                {
                    throw new NullReferenceException("Valor não encontrado");
                }
                return speciality;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR001: {ex.Message} ");
            }
        }

        public async Task<IEnumerable<Speciality>> GetValues()
        {
            try
            {
                var list = await dbcontext.Tb_Speciality.ToListAsync();
                return list;
                //throw new NullReferenceException($"Nenhum valor encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }

        public async Task NewSpeciality(SpecialityDTO entity)
        {
            try
            {

                var newAdd = new Speciality
                {
                    Id = Guid.NewGuid(),
                    SpecialityName = entity.Name.ToUpper(),
                    CreatedAt = DateTime.UtcNow,
                };

                await dbcontext.AddRangeAsync(newAdd);
                await dbcontext.SaveChangesAsync();
                dbcontext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nº BR001: {ex.Message}");
            }
        }

        public async Task<Speciality> Update(SpecialityDTO entity, Guid Id)
        {
            try
            {
                var speciality = await dbcontext.Tb_Speciality.FindAsync(Id);
                if (speciality != null || speciality.Id != Id)
                {
                    speciality.SpecialityName = entity.Name.ToUpper();
                    speciality.UpdatedAt = DateTime.UtcNow;

                    await dbcontext.SaveChangesAsync();
                    await dbcontext.DisposeAsync();
                    return speciality;
                }
                else
                {
                    throw new NullReferenceException("Dado não encontrado. ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR001: {ex.Message} ");
            }
        }
    }
}