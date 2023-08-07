using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IBloodRepository
    {
        Task <IEnumerable<Blood>> GetValues();
        Task<Blood> GetValue(int id);
        Task NewBlood(BloodDTo entity);
        Task<Blood> Update(BloodDTo entity, int Id);
        Task Delete(int id);
    }
}