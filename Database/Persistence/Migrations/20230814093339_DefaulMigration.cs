using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DefaulMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Blood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Blood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumeber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EmailAdrress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    HousePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Speciality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_StockHold",
                columns: table => new
                {
                    StockHoldId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_StockHold", x => x.StockHoldId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GeoLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GetCountryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Province_Tb_Country_GetCountryId",
                        column: x => x.GetCountryId,
                        principalTable: "Tb_Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_TownShiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GetProvinceId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_TownShiep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_TownShiep_Tb_Province_GetProvinceId",
                        column: x => x.GetProvinceId,
                        principalTable: "Tb_Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NeighborHud = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GetTownShiepId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Address_Tb_TownShiep_GetTownShiepId",
                        column: x => x.GetTownShiepId,
                        principalTable: "Tb_TownShiep",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GetAddressId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Hospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Hospital_Tb_Address_GetAddressId",
                        column: x => x.GetAddressId,
                        principalTable: "Tb_Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdentDocNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TypeIdentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    GetAddressId = table.Column<int>(type: "int", nullable: true),
                    GetBloodId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Person_Tb_Address_GetAddressId",
                        column: x => x.GetAddressId,
                        principalTable: "Tb_Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tb_Person_Tb_Blood_GetBloodId",
                        column: x => x.GetBloodId,
                        principalTable: "Tb_Blood",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tb_Person_Tb_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Tb_Contact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BloodGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GetPersonId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Doctor_Tb_Person_GetPersonId",
                        column: x => x.GetPersonId,
                        principalTable: "Tb_Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_Donor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BloodGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonorType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastGivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextGivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemaingDays = table.Column<int>(type: "int", nullable: false),
                    IsElegilbe = table.Column<bool>(type: "bit", nullable: true),
                    GetPersonId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Donor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Donor_Tb_Person_GetPersonId",
                        column: x => x.GetPersonId,
                        principalTable: "Tb_Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_DocSpeciality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_DocSpeciality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_DocSpeciality_Tb_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Tb_Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_DocSpeciality_Tb_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Tb_Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_BloodRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAcepted = table.Column<bool>(type: "bit", nullable: false),
                    DiseasedName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsHomeDonor = table.Column<bool>(type: "bit", nullable: false),
                    HasFamDonor = table.Column<bool>(type: "bit", nullable: false),
                    DiseasedAge = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetDonorId = table.Column<int>(type: "int", nullable: true),
                    GetHospitalId = table.Column<int>(type: "int", nullable: true),
                    GetBloodId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_BloodRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_BloodRequest_Tb_Blood_GetBloodId",
                        column: x => x.GetBloodId,
                        principalTable: "Tb_Blood",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tb_BloodRequest_Tb_Donor_GetDonorId",
                        column: x => x.GetDonorId,
                        principalTable: "Tb_Donor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tb_BloodRequest_Tb_Hospital_GetHospitalId",
                        column: x => x.GetHospitalId,
                        principalTable: "Tb_Hospital",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_Donation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Donation_Tb_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Tb_Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Address_GetTownShiepId",
                table: "Tb_Address",
                column: "GetTownShiepId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Blood_BloodGroupName",
                table: "Tb_Blood",
                column: "BloodGroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_BloodRequest_GetBloodId",
                table: "Tb_BloodRequest",
                column: "GetBloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_BloodRequest_GetDonorId",
                table: "Tb_BloodRequest",
                column: "GetDonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_BloodRequest_GetHospitalId",
                table: "Tb_BloodRequest",
                column: "GetHospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Country_CountryName",
                table: "Tb_Country",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Country_PhoneCode",
                table: "Tb_Country",
                column: "PhoneCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_DocSpeciality_DoctorId",
                table: "Tb_DocSpeciality",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_DocSpeciality_SpecialityId",
                table: "Tb_DocSpeciality",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Doctor_DocNumber",
                table: "Tb_Doctor",
                column: "DocNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Doctor_GetPersonId",
                table: "Tb_Doctor",
                column: "GetPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Donation_DonorId",
                table: "Tb_Donation",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Donor_GetPersonId",
                table: "Tb_Donor",
                column: "GetPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Hospital_GetAddressId",
                table: "Tb_Hospital",
                column: "GetAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Person_ContactId",
                table: "Tb_Person",
                column: "ContactId",
                unique: true,
                filter: "[ContactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Person_GetAddressId",
                table: "Tb_Person",
                column: "GetAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Person_GetBloodId",
                table: "Tb_Person",
                column: "GetBloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Person_IdentDocNumber",
                table: "Tb_Person",
                column: "IdentDocNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Province_GetCountryId",
                table: "Tb_Province",
                column: "GetCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_StockHold_StockHoldId",
                table: "Tb_StockHold",
                column: "StockHoldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_TownShiep_GetProvinceId",
                table: "Tb_TownShiep",
                column: "GetProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tb_BloodRequest");

            migrationBuilder.DropTable(
                name: "Tb_DocSpeciality");

            migrationBuilder.DropTable(
                name: "Tb_Donation");

            migrationBuilder.DropTable(
                name: "Tb_StockHold");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tb_Hospital");

            migrationBuilder.DropTable(
                name: "Tb_Doctor");

            migrationBuilder.DropTable(
                name: "Tb_Speciality");

            migrationBuilder.DropTable(
                name: "Tb_Donor");

            migrationBuilder.DropTable(
                name: "Tb_Person");

            migrationBuilder.DropTable(
                name: "Tb_Address");

            migrationBuilder.DropTable(
                name: "Tb_Blood");

            migrationBuilder.DropTable(
                name: "Tb_Contact");

            migrationBuilder.DropTable(
                name: "Tb_TownShiep");

            migrationBuilder.DropTable(
                name: "Tb_Province");

            migrationBuilder.DropTable(
                name: "Tb_Country");
        }
    }
}
