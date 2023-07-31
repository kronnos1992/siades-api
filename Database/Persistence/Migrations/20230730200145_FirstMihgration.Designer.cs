﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using siades.Database.DataContext;

#nullable disable

namespace siades.Database.Persistence.Migrations
{
    [DbContext(typeof(SiadesDbContext))]
    [Migration("20230730200145_FirstMihgration")]
    partial class FirstMihgration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("siades.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NeighborHud")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("TownShiepId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TownShiepId");

                    b.ToTable("Tb_Address");
                });

            modelBuilder.Entity("siades.Models.BirthAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BirthHouseNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BirthNeighborHud")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BirthStreet")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TownShiepId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TownShiepId");

                    b.ToTable("Tb_BirthAddress");
                });

            modelBuilder.Entity("siades.Models.Blood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BloodGroupName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tb_Blood");
                });

            modelBuilder.Entity("siades.Models.BloodRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AskingAcepted")
                        .HasColumnType("bit");

                    b.Property<Guid>("BloodDescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiseasedAge")
                        .HasColumnType("int");

                    b.Property<string>("DiseasedName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GetBloodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasFamDonor")
                        .HasColumnType("bit");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsHomeDonor")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DonorId");

                    b.HasIndex("GetBloodId");

                    b.HasIndex("HospitalId");

                    b.ToTable("Tb_BloodRequest");
                });

            modelBuilder.Entity("siades.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAdrress")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("HousePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumeber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tb_Contact");
                });

            modelBuilder.Entity("siades.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tb_Country");
                });

            modelBuilder.Entity("siades.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Tb_Doctor");
                });

            modelBuilder.Entity("siades.Models.Donation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StockHoldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DonorId");

                    b.HasIndex("StockHoldId");

                    b.ToTable("Tb_Donation");
                });

            modelBuilder.Entity("siades.Models.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FirstGivenDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastGivenDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextGivenDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RefNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Tb_Donor");
                });

            modelBuilder.Entity("siades.Models.Hospital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Tb_Hospital");
                });

            modelBuilder.Entity("siades.Models.HospitalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HospitalService");
                });

            modelBuilder.Entity("siades.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BirthAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BloodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("IdentDocNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TypeIdentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BirthAddressId");

                    b.HasIndex("BloodId");

                    b.HasIndex("ContactId")
                        .IsUnique();

                    b.ToTable("Tb_Person");
                });

            modelBuilder.Entity("siades.Models.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GeoLocation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Tb_Province");
                });

            modelBuilder.Entity("siades.Models.RelHospService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HospitalServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("HospitalServiceId");

                    b.ToTable("RelHospService");
                });

            modelBuilder.Entity("siades.Models.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tb_Speciality");
                });

            modelBuilder.Entity("siades.Models.StockHold", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BloodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BloodId");

                    b.ToTable("Tb_StockHold");
                });

            modelBuilder.Entity("siades.Models.TownShiep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TownName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Tb_TownShiep");
                });

            modelBuilder.Entity("siades.Models.Address", b =>
                {
                    b.HasOne("siades.Models.TownShiep", "GetTownShiep")
                        .WithMany("AddressesList")
                        .HasForeignKey("TownShiepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetTownShiep");
                });

            modelBuilder.Entity("siades.Models.BirthAddress", b =>
                {
                    b.HasOne("siades.Models.TownShiep", "GetTownShiep")
                        .WithMany("BirthAddressesList")
                        .HasForeignKey("TownShiepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetTownShiep");
                });

            modelBuilder.Entity("siades.Models.BloodRequest", b =>
                {
                    b.HasOne("siades.Models.Donor", "GetDonor")
                        .WithMany()
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.Blood", "GetBlood")
                        .WithMany("ListRequest")
                        .HasForeignKey("GetBloodId");

                    b.HasOne("siades.Models.Hospital", "GetHospital")
                        .WithMany("ListRequest")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetBlood");

                    b.Navigation("GetDonor");

                    b.Navigation("GetHospital");
                });

            modelBuilder.Entity("siades.Models.Doctor", b =>
                {
                    b.HasOne("siades.Models.Person", "GetPerson")
                        .WithMany("DoctorsList")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.Speciality", "GetSpeciality")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetPerson");

                    b.Navigation("GetSpeciality");
                });

            modelBuilder.Entity("siades.Models.Donation", b =>
                {
                    b.HasOne("siades.Models.Donor", "GetDonor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.StockHold", "GetStock")
                        .WithMany()
                        .HasForeignKey("StockHoldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetDonor");

                    b.Navigation("GetStock");
                });

            modelBuilder.Entity("siades.Models.Donor", b =>
                {
                    b.HasOne("siades.Models.Person", "GetPerson")
                        .WithMany("DonorsList")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetPerson");
                });

            modelBuilder.Entity("siades.Models.Hospital", b =>
                {
                    b.HasOne("siades.Models.Address", "GetAddress")
                        .WithOne("GetHospital")
                        .HasForeignKey("siades.Models.Hospital", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetAddress");
                });

            modelBuilder.Entity("siades.Models.Person", b =>
                {
                    b.HasOne("siades.Models.Address", "GetAddress")
                        .WithMany("People")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.BirthAddress", "GetBirthAddress")
                        .WithMany("People")
                        .HasForeignKey("BirthAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.Blood", "GetBlood")
                        .WithMany("People")
                        .HasForeignKey("BloodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.Contact", "GetContact")
                        .WithOne("GetPerson")
                        .HasForeignKey("siades.Models.Person", "ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetAddress");

                    b.Navigation("GetBirthAddress");

                    b.Navigation("GetBlood");

                    b.Navigation("GetContact");
                });

            modelBuilder.Entity("siades.Models.Province", b =>
                {
                    b.HasOne("siades.Models.Country", "GetCountry")
                        .WithMany("ProvinceList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetCountry");
                });

            modelBuilder.Entity("siades.Models.RelHospService", b =>
                {
                    b.HasOne("siades.Models.Hospital", "GetHospital")
                        .WithMany("Services")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.HospitalService", "GetService")
                        .WithMany("Hospitals")
                        .HasForeignKey("HospitalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetHospital");

                    b.Navigation("GetService");
                });

            modelBuilder.Entity("siades.Models.StockHold", b =>
                {
                    b.HasOne("siades.Models.Blood", "GetBlood")
                        .WithMany()
                        .HasForeignKey("BloodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetBlood");
                });

            modelBuilder.Entity("siades.Models.TownShiep", b =>
                {
                    b.HasOne("siades.Models.Province", "GetProvince")
                        .WithMany("TownShiepsList")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetProvince");
                });

            modelBuilder.Entity("siades.Models.Address", b =>
                {
                    b.Navigation("GetHospital");

                    b.Navigation("People");
                });

            modelBuilder.Entity("siades.Models.BirthAddress", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("siades.Models.Blood", b =>
                {
                    b.Navigation("ListRequest");

                    b.Navigation("People");
                });

            modelBuilder.Entity("siades.Models.Contact", b =>
                {
                    b.Navigation("GetPerson");
                });

            modelBuilder.Entity("siades.Models.Country", b =>
                {
                    b.Navigation("ProvinceList");
                });

            modelBuilder.Entity("siades.Models.Donor", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("siades.Models.Hospital", b =>
                {
                    b.Navigation("ListRequest");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("siades.Models.HospitalService", b =>
                {
                    b.Navigation("Hospitals");
                });

            modelBuilder.Entity("siades.Models.Person", b =>
                {
                    b.Navigation("DoctorsList");

                    b.Navigation("DonorsList");
                });

            modelBuilder.Entity("siades.Models.Province", b =>
                {
                    b.Navigation("TownShiepsList");
                });

            modelBuilder.Entity("siades.Models.Speciality", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("siades.Models.TownShiep", b =>
                {
                    b.Navigation("AddressesList");

                    b.Navigation("BirthAddressesList");
                });
#pragma warning restore 612, 618
        }
    }
}
