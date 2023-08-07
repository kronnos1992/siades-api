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
        Task<Donor> GetValue(int id);
        Task NewDonor(DonorDTO entity, int bloodId, int townId);
        Task<Donor> Update(DonorDTO entity, int id);
        Task Delete(int id);
    }
}