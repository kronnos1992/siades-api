using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface IDoctoRepository
    {
        Task<IEnumerable<Doctor>> GetValues();
        Task<Doctor> GetValue(int id);
        Task NewDoctor(DoctorDTO entity, int bloodId, int townId);
        Task LinkDocSpeciality(int doctor, int speciality);
        Task<Doctor> Update(DoctorDTO entity, int Id);
        Task Delete(int id);
    }
}