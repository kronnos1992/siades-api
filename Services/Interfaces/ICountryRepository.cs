using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using siades.Models;
using siades.Services.DTOs.BloodDTO;

namespace siades.Services.Interfaces
{
    public interface ICountryRepository
    {
        Task <IEnumerable<Country>> GetValues();
        Task<Country> GetValue(int id);
        Task NewCountry(CountryDTO entity);
        Task<Country> Update(CountryDTO entity, int Id);
        Task Delete(int id);
    }
}