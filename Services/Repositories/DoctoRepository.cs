using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Models;
using siades.Services.DTOs;
using siades.Services.Interfaces;

namespace siades.Services.Repositories
{
    public class DoctoRepository : IDoctoRepository
    {
        private readonly SiadesDbContext dbcontext;

        public DoctoRepository(SiadesDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task Delete(Guid id)
        {
            try
            {
                var doctor = await dbcontext.Tb_Doctor.FindAsync(id);
                dbcontext.RemoveRange(doctor);
                await dbcontext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }

        public async Task<Doctor> GetValue(Guid id)
        {
            try
            {
                var doctor = await dbcontext.Tb_Doctor
                    .Include(x => x.Specialities)
                    .FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new NullReferenceException("Valor não encontrado");
                return doctor;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR001: {ex.Message} ");
            }
        }

        public async Task<IEnumerable<Doctor>> GetValues()
        {
            try
            {
                var list = await dbcontext.Tb_Doctor
                    .Include(x => x.Specialities)
                    .ToListAsync();
                return list;
                //throw new NullReferenceException($"Nenhum valor encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }

        public async Task LinkDocSpeciality(Guid doctor, Guid speciality)
        {
            try
            {
                var getDoctor = await dbcontext.Tb_Doctor.FindAsync(doctor);
                var getSpeciality = await dbcontext.Tb_Speciality.FindAsync(speciality);

                var newData = new SpecialityDoctor
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    GetDoctor = getDoctor,
                    GetSpeciality = getSpeciality
                };

                await dbcontext.AddAsync(newData);
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task NewDoctor(DoctorDTO entity, Guid townId, Guid bloodId)
        {
            try
            {
                var townShiep = dbcontext.Tb_TownShiep.SingleOrDefault(x => x.Id == townId);
                var blood = dbcontext.Tb_Blood.SingleOrDefault(x => x.Id == bloodId);

                var newDoctor = new Doctor
                {
                    // doctor
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    DocNumber = entity.DoctorNumber,

                    //Person
                    GetPerson = new Person
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        //person
                        FullName = entity.FullName,
                        IdentDocNumber = entity.IdNumber,
                        TypeIdentNumber = entity.TypeDocId,

                        GetContact = new Contact
                        {
                            Id = Guid.NewGuid(),
                            CreatedAt = DateTime.Now,
                            // contact
                            PhoneNumeber = entity.PhoneNumber,
                            HousePhoneNumber = entity.HouseNumber,
                            EmailAdrress = entity.EmailAdrress,
                        },

                        GetAddress = new Address
                        {
                            Id = Guid.NewGuid(),
                            CreatedAt = DateTime.Now,
                            //address
                            Street = entity.Street,
                            HouseNumber = entity.HouseNumber,
                            NeighborHud = entity.NeighborHud,
                            GetTownShiep = townShiep
                        },
                        GetBlood = blood
                    },

                };

                await dbcontext.AddRangeAsync(newDoctor);
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor> Update(DoctorDTO entity, Guid Id)
        {
            try
            {
                var doctor = await dbcontext.Tb_Doctor
                    .FirstOrDefaultAsync(x => x.Id == Id);
                if (doctor.ToString().Length > 0)
                {
                    doctor.UpdatedAt = DateTime.Now;
                    doctor.GetPerson.CreatedAt = DateTime.Now;
                    doctor.GetPerson.GetContact.UpdatedAt = DateTime.Now;
                    doctor.GetPerson.GetAddress.UpdatedAt = DateTime.Now;

                    doctor.DocNumber = entity.DoctorNumber.Trim().ToUpper();
                    doctor.GetPerson.IdentDocNumber = entity.IdNumber.Trim().ToUpper();
                    doctor.GetPerson.TypeIdentNumber = entity.TypeDocId.Trim().ToUpper();
                    doctor.GetPerson.FullName = entity.FullName.Trim().ToUpper();
                    doctor.GetPerson.GetContact.PhoneNumeber = entity.PhoneNumber.Trim().ToUpper();
                    doctor.GetPerson.GetContact.HousePhoneNumber = entity.HousePhoneNumber.Trim().ToUpper();
                    doctor.GetPerson.GetContact.EmailAdrress = entity.EmailAdrress.Trim().ToUpper();
                    doctor.GetPerson.GetAddress.Street = entity.Street.Trim().ToUpper();
                    doctor.GetPerson.GetAddress.HouseNumber = entity.HouseNumber.Trim().ToUpper();
                    doctor.GetPerson.GetAddress.NeighborHud = entity.NeighborHud.Trim().ToUpper();

                    dbcontext.UpdateRange(doctor);
                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    throw new NullReferenceException("Registro não encontrado");
                }
                return doctor;
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}