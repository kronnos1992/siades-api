using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using siades.Models;
using siades.Services.DTOs.DonorDTO;

namespace siades.Services.Interfaces
{
    public interface IDonoRepository
    {
        Task <IEnumerable<Donor>> GetValues();
        Task<Donor> GetValue(Guid id);
        Task NewDonor(DonorDTO entity);
        Task<Donor> Update(DonorDTO entity, Guid Id);
        Task Delete(Guid id);
    }
}