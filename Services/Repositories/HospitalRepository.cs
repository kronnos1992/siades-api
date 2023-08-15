using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly SiadesDbContext dbcontext;

        public HospitalRepository(SiadesDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task Delete(int id)
        {
            try
            {
                var hospital = dbcontext.Tb_Hospital.FirstOrDefault(x => x.Id == id);
                if (hospital.ToString().Length > 0)
                {
                    dbcontext.RemoveRange(id);
                    await dbcontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Hospital> GetValue(int id)
        {
            try
            {
                var hospital = await dbcontext.Tb_Hospital.FirstOrDefaultAsync(x => x.Id == id);
                if (hospital.ToString().Length > 0)
                {
                    return hospital;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Hospital>> GetValues()
        {
            try
            {
                var hospital = await dbcontext.Tb_Hospital.ToListAsync();
                if (hospital.Count > 0)
                {
                    return hospital;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task NewHospital(HospitalDTO entity, int townId)
        {
            var town = dbcontext.Tb_TownShiep
                .FirstOrDefault(h => h.Id == townId);
            try
            {
                var hospital = new Hospital
                {
                    HospitalName = entity.HospitalName,
                    CreatedAt = DateTime.Now,
                    GetAddress = new Address
                    {
                        CreatedAt = DateTime.Now,
                        Street = entity.Street,
                        HouseNumber = entity.HouseNumber,
                        NeighborHud = entity.NeighborHud,
                        GetTownShiep = town
                    }
                };
                await dbcontext.AddRangeAsync(hospital);
                await dbcontext.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Hospital> Update(HospitalDTO entity, int hospitalId)
        {
            try
            {
                var hospital = dbcontext.Tb_Hospital.FirstOrDefault(x => x.Id == hospitalId);
                if (hospital.ToString().Length > 0)
                {

                    hospital.UpdatedAt = DateTime.Now;
                    hospital.HospitalName = entity.HospitalName;
                    hospital.GetAddress.UpdatedAt = DateTime.Now;
                    hospital.GetAddress.HouseNumber = entity.HouseNumber;
                    hospital.GetAddress.NeighborHud = entity.NeighborHud;
                    hospital.GetAddress.Street = entity.Street;

                    dbcontext.UpdateRange(hospital);
                    await dbcontext.SaveChangesAsync();
                    return hospital;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not update hospital with id {ex.Message}");
            }
        }
    }
}