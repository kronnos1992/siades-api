

using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetValues();
        Task<Hospital> GetValue(Guid id);
        Task NewHospital(HospitalDTO entity, Guid townId);
        Task<Hospital> Update(HospitalDTO entity, Guid Id);
        Task Delete(Guid id);
    }
}