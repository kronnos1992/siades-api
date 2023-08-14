using System.Text.RegularExpressions;
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
        private readonly string _regex = @"^[0-9]{9}[a-zA-Z]{2}[0-9]{3}$";
        private readonly string _regex2 = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";


        public DoctoRepository(SiadesDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task Delete(int id)
        {
            try
            {
                // se doctor for nulo, então retorna vazio
                var doctor = await dbcontext.Tb_Doctor.FindAsync(id);
                if (doctor != null)
                {
                    dbcontext.RemoveRange(doctor);
                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    throw new NullReferenceException("Valor não encontrado.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }

        public async Task<Doctor> GetValue(int id)
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
                var list = await dbcontext.Tb_Doctor.ToListAsync();
                if (list.Count >= 0)
                {
                    return list;
                }

                throw new NullReferenceException("Nenhum valor encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro nºBR002: {ex.Message} ");
            }
        }

        public async Task LinkDocSpeciality(int doctor, int speciality)
        {
            try
            {
                var getDoctor = await dbcontext.Tb_Doctor.SingleOrDefaultAsync(x => x.Id == doctor);
                var getSpeciality = await dbcontext.Tb_Speciality.SingleOrDefaultAsync(x => x.Id == speciality);

                if (getDoctor != null && getSpeciality != null)
                {
                    var newData = new SpecialityDoctor
                    {
                        CreatedAt = DateTime.Now,
                        DoctorId = getDoctor.Id,
                        SpecialityId = getSpeciality.Id,
                    };

                    await dbcontext.AddAsync(newData);
                    await dbcontext.SaveChangesAsync();
                }
                //throw new NullReferenceException("Selecione o médico e a especialidade.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task NewDoctor(DoctorDTO entity, int bloodId, int townId)
        {
            try
            {
                var blood = dbcontext.Tb_Blood.SingleOrDefault(x => x.Id == bloodId);
                var townShiep = dbcontext.Tb_TownShiep.SingleOrDefault(x => x.Id == townId);

                if (blood != null && townShiep != null)
                {
                    if (!Regex.IsMatch(entity.IdNumber.Trim().ToUpper(), _regex))
                        throw new ArgumentException("O numero de bilhete identidade foi mal escrito.");

                    if (!Regex.IsMatch(entity.EmailAdrress.Trim().ToLower(), _regex2))
                        throw new ArgumentException("= endereço de email foi mal escrito.");

                    var newDoctor = new Doctor
                    {
                        // doctor
                        CreatedAt = DateTime.Now,
                        DocNumber = entity.DoctorNumber,
                        BloodGroupName = blood.BloodGroupName,
                        //Person
                        GetPerson = new Person
                        {

                            CreatedAt = DateTime.Now,
                            //person
                            FullName = entity.FullName,
                            IdentDocNumber = entity.IdNumber,
                            TypeIdentNumber = entity.TypeDocId,
                            GetAddress = new Address
                            {

                                CreatedAt = DateTime.Now,
                                Street = entity.Street,
                                HouseNumber = entity.HouseNumber,
                                NeighborHud = entity.NeighborHud,
                                GetTownShiep = townShiep
                            },
                            GetContact = new Contact
                            {

                                CreatedAt = DateTime.Now,
                                PhoneNumeber = entity.PhoneNumber,
                                HousePhoneNumber = entity.HouseNumber,
                                EmailAdrress = entity.EmailAdrress,
                            },
                            GetBlood = blood
                        },

                    };

                    await dbcontext.AddRangeAsync(newDoctor);
                    await dbcontext.SaveChangesAsync();
                }
                throw new Exception("Informe o grupo sanguineo e o municipio.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor> Update(DoctorDTO entity, int Id)
        {
            try
            {
                var doctor = await dbcontext.Tb_Doctor
                    .FirstOrDefaultAsync(x => x.Id == Id);

                if (!Regex.IsMatch(entity.IdNumber.Trim().ToUpper(), _regex))
                    throw new ArgumentException("O bilhete de identidade nao corresponde o padrão 000000000AZ000.");
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