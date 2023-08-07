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
    public class RequestRepository : IRequestRepository
    {
        public readonly SiadesDbContext dbContext;
        public RequestRepository(SiadesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AproveRequest(int id)
        {
            try
            {
                var request = await dbContext.Tb_BloodRequest.FirstOrDefaultAsync(x => x.Id == id);
                var reduceInStock = await dbContext.Tb_StockHold.SingleOrDefaultAsync(x => x.StockHoldId == request.BloodGroup);
                if (request.ToString().Length > 0)
                {
                    request.IsAcepted = true;
                    if (reduceInStock != null)
                        reduceInStock.Qty -= request.Qty;

                    dbContext.UpdateRange(request, reduceInStock);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task CreateRequest(RequestDTO entity, int donorId, int hospitalId, int bloodId)
        {
            var donor = await dbContext.Tb_Donor
                .FirstOrDefaultAsync(x => x.Id.Equals(donorId));

            var blood = await dbContext.Tb_Blood
                .FirstOrDefaultAsync(x => x.Id.Equals(bloodId));

            var hospital = await dbContext.Tb_Hospital
                .FirstOrDefaultAsync(x => x.Id.Equals(donorId));



            var request = new BloodRequest()
            {
                CreatedAt = DateTime.Now,
                IsHomeDonor = entity.IsHomeDonor,
                HasFamDonor = entity.HasFamDonor,
                DiseasedAge = entity.DiseasedAge,
                DiseasedName = entity.DiseasedName,
                BloodGroup = blood.BloodGroupName,
                Qty = entity.Qty,
                GetBlood = blood,
                GetDonor = donor,
                GetHospital = hospital,
            };
            await dbContext.AddRangeAsync(request);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRequest(int id)
        {
            try
            {
                var request = await dbContext
                .Tb_BloodRequest
                .FirstOrDefaultAsync(x => x.Id == id);

                if (request.ToString().Length > 0)
                {
                    dbContext.RemoveRange(request);
                    await dbContext.SaveChangesAsync();
                }
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<BloodRequest> ShowRequest(int id)
        {
            try
            {
                var request = await dbContext.Tb_BloodRequest.FirstOrDefaultAsync(x => x.Id == id);

                if (request.ToString().Length > 0)
                {
                    return request;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<IEnumerable<BloodRequest>> ShowRequests()
        {
            try
            {
                var request = await dbContext
                .Tb_BloodRequest
                .ToListAsync();

                if (request.ToString().Length > 0)
                {
                    return request;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<BloodRequest> UpdateRequest(RequestDTO entity, int Id)
        {
            try
            {
                var request = await dbContext
                    .Tb_BloodRequest
                    .FirstOrDefaultAsync(x => x.Id == Id);

                if (request.ToString().Length > 0)
                {
                    request.DiseasedAge = entity.DiseasedAge;
                    request.DiseasedName = entity.DiseasedName;
                    request.IsHomeDonor = entity.IsHomeDonor;
                    request.HasFamDonor = entity.HasFamDonor;
                    request.IsAcepted = entity.IsAcepted;
                    request.UpdatedAt = DateTime.Now;

                    dbContext.UpdateRange(request);
                    await dbContext.SaveChangesAsync();
                    await dbContext.SaveChangesAsync();
                }
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }


        }
    }
}