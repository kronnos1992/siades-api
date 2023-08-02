using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Blood",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumeber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EmailAdrress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    HousePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    BloodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_StockHold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_StockHold_Tb_Blood_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Tb_Blood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Province",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GeoLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Province_Tb_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Tb_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_TownShiep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_TownShiep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_TownShiep_Tb_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Tb_Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NeighborHud = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TownShiepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Address_Tb_TownShiep_TownShiepId",
                        column: x => x.TownShiepId,
                        principalTable: "Tb_TownShiep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Hospital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Hospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Hospital_Tb_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Tb_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdentDocNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TypeIdentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Person_Tb_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Tb_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_Person_Tb_Blood_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Tb_Blood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_Person_Tb_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Tb_Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RelHospService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HospitalServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HospitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelHospService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelHospService_HospitalService_HospitalServiceId",
                        column: x => x.HospitalServiceId,
                        principalTable: "HospitalService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RelHospService_Tb_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Tb_Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Doctor_Tb_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tb_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Donor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonorType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstGivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastGivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextGivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Donor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Donor_Tb_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tb_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpecialityDoctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialityDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialityDoctor_Tb_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Tb_Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpecialityDoctor_Tb_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Tb_Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_BloodRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AskingAcepted = table.Column<bool>(type: "bit", nullable: false),
                    DiseasedName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsHomeDonor = table.Column<bool>(type: "bit", nullable: false),
                    HasFamDonor = table.Column<bool>(type: "bit", nullable: false),
                    DiseasedAge = table.Column<int>(type: "int", nullable: false),
                    BloodDescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HospitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GetBloodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_Tb_BloodRequest_Tb_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Tb_Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_BloodRequest_Tb_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Tb_Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Donation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockHoldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_Donation_Tb_StockHold_StockHoldId",
                        column: x => x.StockHoldId,
                        principalTable: "Tb_StockHold",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelHospService_HospitalId",
                table: "RelHospService",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_RelHospService_HospitalServiceId",
                table: "RelHospService",
                column: "HospitalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_DoctorId",
                table: "SpecialityDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_SpecialityId",
                table: "SpecialityDoctor",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Address_TownShiepId",
                table: "Tb_Address",
                column: "TownShiepId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_BloodRequest_DonorId",
                table: "Tb_BloodRequest",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_BloodRequest_GetBloodId",
                table: "Tb_BloodRequest",
                column: "GetBloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_BloodRequest_HospitalId",
                table: "Tb_BloodRequest",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Doctor_PersonId",
                table: "Tb_Doctor",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Donation_DonorId",
                table: "Tb_Donation",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Donation_StockHoldId",
                table: "Tb_Donation",
                column: "StockHoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Donor_PersonId",
                table: "Tb_Donor",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Hospital_AddressId",
                table: "Tb_Hospital",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Person_AddressId",
                table: "Tb_Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Person_BloodId",
                table: "Tb_Person",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Person_ContactId",
                table: "Tb_Person",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Province_CountryId",
                table: "Tb_Province",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_StockHold_BloodId",
                table: "Tb_StockHold",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_TownShiep_ProvinceId",
                table: "Tb_TownShiep",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelHospService");

            migrationBuilder.DropTable(
                name: "SpecialityDoctor");

            migrationBuilder.DropTable(
                name: "Tb_BloodRequest");

            migrationBuilder.DropTable(
                name: "Tb_Donation");

            migrationBuilder.DropTable(
                name: "HospitalService");

            migrationBuilder.DropTable(
                name: "Tb_Doctor");

            migrationBuilder.DropTable(
                name: "Tb_Speciality");

            migrationBuilder.DropTable(
                name: "Tb_Hospital");

            migrationBuilder.DropTable(
                name: "Tb_Donor");

            migrationBuilder.DropTable(
                name: "Tb_StockHold");

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
