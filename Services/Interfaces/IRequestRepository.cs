using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IRequestRepository
    {
        Task<IEnumerable<BloodRequest>> ShowRequests();
        Task<BloodRequest> ShowRequest(int id);
        Task CreateRequest(RequestDTO entity, int donorId, int hospitalId, int bloodId);
        Task<BloodRequest> UpdateRequest(RequestDTO entity, int Id);
        Task AproveRequest(int id);
        Task DeleteRequest(int id);
    }
}