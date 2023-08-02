using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IDoctoRepository
    {
        Task<IEnumerable<Doctor>> GetValues();
        Task<Doctor> GetValue(Guid id);
        Task NewDoctor(DoctorDTO entity, Guid provinceId, Guid bloodId);
        Task LinkDocSpeciality(Guid doctor, Guid speciality);
        Task<Doctor> Update(DoctorDTO entity, Guid Id);
        Task Delete(Guid id);
    }
}