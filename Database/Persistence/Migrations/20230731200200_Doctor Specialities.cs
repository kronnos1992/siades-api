using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DoctorSpecialities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Doctor_Tb_Speciality_SpecialityId",
                table: "Tb_Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Doctor_SpecialityId",
                table: "Tb_Doctor");

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialityDoctor_Tb_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Tb_Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_DoctorId",
                table: "SpecialityDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_SpecialityId",
                table: "SpecialityDoctor",
                column: "SpecialityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialityDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Doctor_SpecialityId",
                table: "Tb_Doctor",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Doctor_Tb_Speciality_SpecialityId",
                table: "Tb_Doctor",
                column: "SpecialityId",
                principalTable: "Tb_Speciality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
