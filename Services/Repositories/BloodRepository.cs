using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class BloodRepository : IBloodRepository
    {
        private readonly SiadesDbContext dbcontext;

        public BloodRepository(SiadesDbContext dbcontext) 
        {
            this.dbcontext = dbcontext;
        }

        public async Task NewBlood(BloodDTo entity)
        {
            try
            {
                var findInStock = dbcontext.Tb_StockHold
                    .Where(p => p.GetBlood.BloodGroupName.Contains(entity.Name));
                
                
                var newAdd = new Blood{
                    Id = Guid.NewGuid(),
                    BloodGroupName = entity.Name.ToUpper(),
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

        public async Task Delete(Guid id)
        {
            
            try
            {
                var blood =await dbcontext.Tb_Blood.FindAsync(id);
                dbcontext.RemoveRange(blood);
                await dbcontext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} "); 
            }
        }

        public async Task<Blood> GetValue(Guid id)
        {
            try
            {
                var blood = await dbcontext.Tb_Blood.FirstOrDefaultAsync(x => x.Id == id);
                if (blood == null)
                {
                    throw new NullReferenceException("Valor não encontrado");
                }
                return blood;
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR001: {ex.Message} "); 
            }
        }

        public async Task<IEnumerable<Blood>> GetValues()
        {
            try
            {
                var list = await dbcontext.Tb_Blood.ToListAsync();
                return list;
                //throw new NullReferenceException($"Nenhum valor encontrado");
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }

        public async Task<Blood> Update(BloodDTo entity, Guid Id)
        {
            try
            {
                var blood =await dbcontext.Tb_Blood.FindAsync(Id);
                if (blood != null || blood.Id != Id)
                {
                    blood.BloodGroupName = entity.Name.ToUpper();
                    blood.UpdatedAt = DateTime.UtcNow;

                    await dbcontext.SaveChangesAsync();
                    await dbcontext.DisposeAsync();
                    return blood;
                }
                else{
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