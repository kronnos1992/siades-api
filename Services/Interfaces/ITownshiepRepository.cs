using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface ITownshiepRepository
    {
        Task <IEnumerable<TownShiep>> GetValues();
        Task<TownShiep> GetValue(int id);
        Task NewTownShiep(TownShiepDTO entity, int countryId);
        Task<TownShiep> Update(TownShiepDTO entity, int Id);
        Task Delete(int id);
    }
}