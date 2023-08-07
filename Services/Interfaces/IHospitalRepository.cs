

using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetValues();
        Task<Hospital> GetValue(int id);
        Task NewHospital(HospitalDTO entity, int townId);
        Task<Hospital> Update(HospitalDTO entity, int Id);
        Task Delete(int id);
    }
}