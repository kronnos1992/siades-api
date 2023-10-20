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
    public class CountryRepository : ICountryRepository
    {
        private readonly SiadesDbContext dbcontext;

        public CountryRepository(SiadesDbContext dbcontext) 
        {
            this.dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Country>> GetValues()
        {
            try
            {
                var list = await dbcontext.Tb_Country.ToListAsync();
                return list;
                //throw new NullReferenceException($"Nenhum valor encontrado");
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }
        public async Task<Country> GetValue(int id)
        {
            try
            {
                var country = await dbcontext.Tb_Country.FirstOrDefaultAsync(x => x.Id == id);
                if (country == null)
                {
                    throw new NullReferenceException("Valor não encontrado");
                }
                return country;
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR001: {ex.Message} "); 
            }
        }
        public async Task NewCountry(CountryDTO entity)
        {
            try
            {

                var newAdd = new Country
                {
                    CountryCode = entity.CountryCode.ToUpper(),
                    CountryName = entity.CountryName.ToUpper(),
                    CreatedAt = DateTime.Now
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
        public async Task<Country> Update(CountryDTO entity, int Id)
        {
             try
            {
                var country = await dbcontext.Tb_Country.FindAsync(Id);
                if (country != null || country.Id != Id)
                {
                    country.CountryName = entity.CountryName.ToUpper();
                    country.CountryCode = entity.CountryCode.ToUpper();
                    country.UpdatedAt = DateTime.UtcNow;

                    await dbcontext.SaveChangesAsync();
                    await dbcontext.DisposeAsync();
                    return country;
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
                var country =await dbcontext.Tb_Country.FindAsync(id);
                dbcontext.RemoveRange(country);
                await dbcontext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
               throw new Exception($"Erro nºBR002: {ex.Message} "); 
            }
        }
    
    }
}