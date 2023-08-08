using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence
{
    /// <inheritdoc />
    public partial class Review7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialityDoctor_Tb_Doctor_GetDoctorId",
                table: "SpecialityDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialityDoctor_Tb_Speciality_GetSpecialityId",
                table: "SpecialityDoctor");

            migrationBuilder.DropIndex(
                name: "IX_SpecialityDoctor_GetDoctorId",
                table: "SpecialityDoctor");

            migrationBuilder.DropIndex(
                name: "IX_SpecialityDoctor_GetSpecialityId",
                table: "SpecialityDoctor");

            migrationBuilder.DropColumn(
                name: "GetDoctorId",
                table: "SpecialityDoctor");

            migrationBuilder.DropColumn(
                name: "GetSpecialityId",
                table: "SpecialityDoctor");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "SpecialityDoctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "SpecialityDoctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_DoctorId",
                table: "SpecialityDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_SpecialityId",
                table: "SpecialityDoctor",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialityDoctor_Tb_Doctor_DoctorId",
                table: "SpecialityDoctor",
                column: "DoctorId",
                principalTable: "Tb_Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialityDoctor_Tb_Speciality_SpecialityId",
                table: "SpecialityDoctor",
                column: "SpecialityId",
                principalTable: "Tb_Speciality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialityDoctor_Tb_Doctor_DoctorId",
                table: "SpecialityDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialityDoctor_Tb_Speciality_SpecialityId",
                table: "SpecialityDoctor");

            migrationBuilder.DropIndex(
                name: "IX_SpecialityDoctor_DoctorId",
                table: "SpecialityDoctor");

            migrationBuilder.DropIndex(
                name: "IX_SpecialityDoctor_SpecialityId",
                table: "SpecialityDoctor");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "SpecialityDoctor");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "SpecialityDoctor");

            migrationBuilder.AddColumn<int>(
                name: "GetDoctorId",
                table: "SpecialityDoctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GetSpecialityId",
                table: "SpecialityDoctor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_GetDoctorId",
                table: "SpecialityDoctor",
                column: "GetDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityDoctor_GetSpecialityId",
                table: "SpecialityDoctor",
                column: "GetSpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialityDoctor_Tb_Doctor_GetDoctorId",
                table: "SpecialityDoctor",
                column: "GetDoctorId",
                principalTable: "Tb_Doctor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialityDoctor_Tb_Speciality_GetSpecialityId",
                table: "SpecialityDoctor",
                column: "GetSpecialityId",
                principalTable: "Tb_Speciality",
                principalColumn: "Id");
        }
    }
}
