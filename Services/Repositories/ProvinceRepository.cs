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
    public class ProvinceRepository : IProvinceRepository
    {
        public SiadesDbContext dbcontext { get; }

        public ProvinceRepository(SiadesDbContext dbcontext) 
        {
            this.dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Province>> GetValues()
        {
            try
            {
                var list = await dbcontext.Tb_Province.ToListAsync();
                return list;
                //throw new NullReferenceException($"Nenhum valor encontrado");
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }
        public async Task<Province> GetValue(int id)
        {
            try
            {
                var Province = await dbcontext.Tb_Province.FirstOrDefaultAsync(x => x.Id == id);
                if (Province == null)
                {
                    throw new NullReferenceException("Valor não encontrado");
                }
                return Province;
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR001: {ex.Message} "); 
            }
        }
        public async Task NewProvince(ProvinceDTO entity, int countryId)
        {
            var country = dbcontext.Tb_Country.FirstOrDefault(x => x.Id == countryId);
            try
            {

                var newAdd = new Province
                {
                    ProvinceName = entity.ProvinceName.ToUpper(),
                    GeoLocation = entity.GeoLocation.ToUpper(),
                    CreatedAt = DateTime.Now,
                    GetCountry = country
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
        public async Task<Province> Update(ProvinceDTO entity, int Id)
        {
            try
            {
                var Province = await dbcontext.Tb_Province.FindAsync(Id);
                if (Province != null || Province.Id != Id)
                {
                    Province.ProvinceName = entity.ProvinceName.ToUpper();
                    Province.GeoLocation = entity.GeoLocation.ToUpper();
                    Province.UpdatedAt = DateTime.UtcNow;

                    await dbcontext.SaveChangesAsync();
                    await dbcontext.DisposeAsync();
                    return Province;
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
                var Province =await dbcontext.Tb_Province.FindAsync(id);
                dbcontext.RemoveRange(Province);
                await dbcontext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} "); 
            }
        }
    
    }
}