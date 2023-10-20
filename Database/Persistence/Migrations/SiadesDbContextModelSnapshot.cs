﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using siades.Database.DataContext;

#nullable disable

namespace siades.Database.Persistence.Migrations
{
    [DbContext(typeof(SiadesDbContext))]
    partial class SiadesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("siades.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GetTownShiepId")
                        .HasColumnType("int");

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

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GetTownShiepId");

                    b.ToTable("Tb_Address");
                });

            modelBuilder.Entity("siades.Models.Auth.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("siades.Models.Auth.AppRoleToUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId1")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("siades.Models.Auth.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("siades.Models.Blood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroupName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupName")
                        .IsUnique();

                    b.ToTable("Tb_Blood");
                });

            modelBuilder.Entity("siades.Models.BloodRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiseasedAge")
                        .HasColumnType("int");

                    b.Property<string>("DiseasedName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("GetBloodId")
                        .HasColumnType("int");

                    b.Property<int?>("GetDonorId")
                        .HasColumnType("int");

                    b.Property<int?>("GetHospitalId")
                        .HasColumnType("int");

                    b.Property<bool>("HasFamDonor")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAcepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHomeDonor")
                        .HasColumnType("bit");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GetBloodId");

                    b.HasIndex("GetDonorId");

                    b.HasIndex("GetHospitalId");

                    b.ToTable("Tb_BloodRequest");
                });

            modelBuilder.Entity("siades.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAdrress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("RegularExpression", "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");

                    b.Property<string>("HousePhoneNumber")
                        .HasColumnType("nvarchar(max)");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode")
                        .IsUnique();

                    b.HasIndex("CountryName")
                        .IsUnique();

                    b.ToTable("Tb_Country");
                });

            modelBuilder.Entity("siades.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroupName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("GetPersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DocNumber")
                        .IsUnique();

                    b.HasIndex("GetPersonId");

                    b.ToTable("Tb_Doctor");
                });

            modelBuilder.Entity("siades.Models.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DonorId");

                    b.ToTable("Tb_Donation");
                });

            modelBuilder.Entity("siades.Models.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("GetPersonId")
                        .HasColumnType("int");

                    b.Property<bool>("IsElegilbe")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastGivenDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextGivenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RemaingDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GetPersonId");

                    b.ToTable("Tb_Donor");
                });

            modelBuilder.Entity("siades.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GetAddressId")
                        .HasColumnType("int");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GetAddressId");

                    b.ToTable("Tb_Hospital");
                });

            modelBuilder.Entity("siades.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("GetAddressId")
                        .HasColumnType("int");

                    b.Property<int?>("GetBloodId")
                        .HasColumnType("int");

                    b.Property<string>("IdentDocNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ImgDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeIdentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasFilter("[ContactId] IS NOT NULL");

                    b.HasIndex("GetAddressId");

                    b.HasIndex("GetBloodId");

                    b.HasIndex("IdentDocNumber")
                        .IsUnique();

                    b.ToTable("Tb_Person");
                });

            modelBuilder.Entity("siades.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GeoLocation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("GetCountryId")
                        .HasColumnType("int");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GetCountryId");

                    b.ToTable("Tb_Province");
                });

            modelBuilder.Entity("siades.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("siades.Models.SpecialityDoctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Tb_DocSpeciality");
                });

            modelBuilder.Entity("siades.Models.StockHold", b =>
                {
                    b.Property<string>("StockHoldId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StockHoldId");

                    b.HasIndex("StockHoldId")
                        .IsUnique();

                    b.ToTable("Tb_StockHold");
                });

            modelBuilder.Entity("siades.Models.TownShiep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GetProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("TownName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GetProvinceId");

                    b.ToTable("Tb_TownShiep");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("siades.Models.Auth.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("siades.Models.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("siades.Models.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("siades.Models.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("siades.Models.Address", b =>
                {
                    b.HasOne("siades.Models.TownShiep", "GetTownShiep")
                        .WithMany("AddressesList")
                        .HasForeignKey("GetTownShiepId");

                    b.Navigation("GetTownShiep");
                });

            modelBuilder.Entity("siades.Models.Auth.AppRoleToUser", b =>
                {
                    b.HasOne("siades.Models.Auth.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.Auth.AppRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId1");

                    b.HasOne("siades.Models.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.Auth.AppUser", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId1");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("siades.Models.BloodRequest", b =>
                {
                    b.HasOne("siades.Models.Blood", "GetBlood")
                        .WithMany("ListRequest")
                        .HasForeignKey("GetBloodId");

                    b.HasOne("siades.Models.Donor", "GetDonor")
                        .WithMany()
                        .HasForeignKey("GetDonorId");

                    b.HasOne("siades.Models.Hospital", "GetHospital")
                        .WithMany("ListRequest")
                        .HasForeignKey("GetHospitalId");

                    b.Navigation("GetBlood");

                    b.Navigation("GetDonor");

                    b.Navigation("GetHospital");
                });

            modelBuilder.Entity("siades.Models.Doctor", b =>
                {
                    b.HasOne("siades.Models.Person", "GetPerson")
                        .WithMany("DoctorsList")
                        .HasForeignKey("GetPersonId");

                    b.Navigation("GetPerson");
                });

            modelBuilder.Entity("siades.Models.Donation", b =>
                {
                    b.HasOne("siades.Models.Donor", "GetDonor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetDonor");
                });

            modelBuilder.Entity("siades.Models.Donor", b =>
                {
                    b.HasOne("siades.Models.Person", "GetPerson")
                        .WithMany("DonorsList")
                        .HasForeignKey("GetPersonId");

                    b.Navigation("GetPerson");
                });

            modelBuilder.Entity("siades.Models.Hospital", b =>
                {
                    b.HasOne("siades.Models.Address", "GetAddress")
                        .WithMany()
                        .HasForeignKey("GetAddressId");

                    b.Navigation("GetAddress");
                });

            modelBuilder.Entity("siades.Models.Person", b =>
                {
                    b.HasOne("siades.Models.Contact", "GetContact")
                        .WithOne("GetPerson")
                        .HasForeignKey("siades.Models.Person", "ContactId");

                    b.HasOne("siades.Models.Address", "GetAddress")
                        .WithMany("People")
                        .HasForeignKey("GetAddressId");

                    b.HasOne("siades.Models.Blood", "GetBlood")
                        .WithMany("People")
                        .HasForeignKey("GetBloodId");

                    b.Navigation("GetAddress");

                    b.Navigation("GetBlood");

                    b.Navigation("GetContact");
                });

            modelBuilder.Entity("siades.Models.Province", b =>
                {
                    b.HasOne("siades.Models.Country", "GetCountry")
                        .WithMany("ProvinceList")
                        .HasForeignKey("GetCountryId");

                    b.Navigation("GetCountry");
                });

            modelBuilder.Entity("siades.Models.SpecialityDoctor", b =>
                {
                    b.HasOne("siades.Models.Doctor", "GetDoctor")
                        .WithMany("Specialities")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("siades.Models.Speciality", "GetSpeciality")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetDoctor");

                    b.Navigation("GetSpeciality");
                });

            modelBuilder.Entity("siades.Models.TownShiep", b =>
                {
                    b.HasOne("siades.Models.Province", "GetProvince")
                        .WithMany("TownShiepsList")
                        .HasForeignKey("GetProvinceId");

                    b.Navigation("GetProvince");
                });

            modelBuilder.Entity("siades.Models.Address", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("siades.Models.Auth.AppRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("siades.Models.Auth.AppUser", b =>
                {
                    b.Navigation("Roles");
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

            modelBuilder.Entity("siades.Models.Doctor", b =>
                {
                    b.Navigation("Specialities");
                });

            modelBuilder.Entity("siades.Models.Donor", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("siades.Models.Hospital", b =>
                {
                    b.Navigation("ListRequest");
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
                });
#pragma warning restore 612, 618
        }
    }
}
