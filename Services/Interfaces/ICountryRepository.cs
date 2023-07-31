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
        Task<Country> GetValue(Guid id);
        Task NewCountry(CountryDTO entity);
        Task<Country> Update(CountryDTO entity, Guid Id);
        Task Delete(Guid id);
    }
}