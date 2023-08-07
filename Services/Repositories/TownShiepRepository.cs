using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class TownShiepRepository : ITownshiepRepository
    {
        public SiadesDbContext dbcontext { get; }

        public TownShiepRepository(SiadesDbContext dbcontext) 
        {
            this.dbcontext = dbcontext;
        }
        public async Task<IEnumerable<TownShiep>> GetValues()
        {
            try
            {
                var list = await dbcontext.Tb_TownShiep.ToListAsync();
                return list;
                //throw new NullReferenceException($"Nenhum valor encontrado");
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }
        public async Task<TownShiep> GetValue(int id)
        {
            try
            {
                var TownShiep = await dbcontext.Tb_TownShiep.FirstOrDefaultAsync(x => x.Id == id);
                if (TownShiep == null)
                {
                    throw new NullReferenceException("Valor não encontrado");
                }
                return TownShiep;
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR001: {ex.Message} "); 
            }
        }
        public async Task NewTownShiep(TownShiepDTO entity, int provinceId)
        {
            var province = await dbcontext.Tb_Province.FindAsync(provinceId);
            try
            {

                var newAdd = new TownShiep
                {
                    TownName = entity.Name.ToUpper(),
                    CreatedAt = DateTime.Now,
                    GetProvince = province
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
        public async Task<TownShiep> Update(TownShiepDTO entity, int Id)
        {
            try
            {
                var townShiep = await dbcontext.Tb_TownShiep.FindAsync(Id);
                if (townShiep != null || townShiep.Id != Id)
                {
                    townShiep.TownName = entity.Name.ToUpper();
                    townShiep.UpdatedAt = DateTime.UtcNow;

                    await dbcontext.SaveChangesAsync();
                    await dbcontext.DisposeAsync();
                    return townShiep;
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
        public async Task Delete(int id)
        {
            try
            {
                var TownShiep =await dbcontext.Tb_TownShiep.FindAsync(id);
                dbcontext.RemoveRange(TownShiep);
                await dbcontext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} "); 
            }
        }
    
    }
}