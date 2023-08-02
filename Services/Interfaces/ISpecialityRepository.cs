using siades.Models;
using siades.Services.DTOs;

namespace siades.Services.Interfaces
{
    public interface ISpecialityRepository
    {
        Task<IEnumerable<Speciality>> GetValues();
        Task<Speciality> GetValue(Guid id);
        Task NewSpeciality(SpecialityDTO entity);
        Task<Speciality> Update(SpecialityDTO entity, Guid Id);
        Task Delete(Guid id);
    }
}