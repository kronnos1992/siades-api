using Microsoft.EntityFrameworkCore;
using siades.Database.Configurations;
using siades.Models;

namespace siades.Database.DataContext
{

    public class SiadesDbContext : DbContext
    {
        public SiadesDbContext(DbContextOptions<SiadesDbContext> options) :base(options)
        {
           
        }

        public DbSet<Address>? Tb_Address { get; set; }
        public DbSet<Person>? Tb_Person { get; set; }
        public DbSet<Contact>? Tb_Contact { get; set; }
        public DbSet<Province>? Tb_Province { get; set; }
        public DbSet<Country>? Tb_Country { get; set; }
        public DbSet<Doctor>? Tb_Doctor { get; set; }
        public DbSet<Donor>? Tb_Donor { get; set; }
        public DbSet<Hospital>? Tb_Hospital { get; set; }
        public DbSet<BloodRequest>? Tb_BloodRequest { get; set; }
        public DbSet<Blood>? Tb_Blood { get; set; }
        public DbSet<StockHold>? Tb_StockHold { get; set; }
        public DbSet<TownShiep>? Tb_TownShiep { get; set; }
        public DbSet<Speciality>? Tb_Speciality {get; set;}
        public DbSet<Donation>? Tb_Donation {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            //modelBuilder.ApplyConfiguration(new BirthAddressConfigurations());
            modelBuilder.ApplyConfiguration(new BloodConfigurations());
            modelBuilder.ApplyConfiguration(new BloodRequestConfigurations());
            modelBuilder.ApplyConfiguration(new DonorConfigurations());
            modelBuilder.ApplyConfiguration(new ContactConfigurations());
            modelBuilder.ApplyConfiguration(new CountryConfigurations());
            modelBuilder.ApplyConfiguration(new DoctorConfigurations());
            modelBuilder.ApplyConfiguration(new DonationConfigurations());
            modelBuilder.ApplyConfiguration(new HospitalConfigurations());
            modelBuilder.ApplyConfiguration(new PersonConfigurations());
            modelBuilder.ApplyConfiguration(new ProvinceConfigurations());
            modelBuilder.ApplyConfiguration(new SpecialityConfigurations());
            modelBuilder.ApplyConfiguration(new StockHoldConfigurations());
            modelBuilder.ApplyConfiguration(new TownShiepConfigurations());
            
            
            base.OnModelCreating(modelBuilder);
        }   
    }
}