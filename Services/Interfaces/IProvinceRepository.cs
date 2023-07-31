using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IProvinceRepository
    {
        Task <IEnumerable<Province>> GetValues();
        Task <Province> GetValue(Guid id);
        Task NewProvince(ProvinceDTO entity, Guid countryId);
        Task <Province> Update(ProvinceDTO entity, Guid Id);
        Task Delete(Guid id);
    }
}