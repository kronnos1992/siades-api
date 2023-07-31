using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IBloodRepository
    {
        Task <IEnumerable<Blood>> GetValues();
        Task<Blood> GetValue(Guid id);
        Task NewBlood(BloodDTo entity);
        Task<Blood> Update(BloodDTo entity, Guid Id);
        Task Delete(Guid id);
    }
}