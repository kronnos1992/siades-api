using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence
{
    /// <inheritdoc />
    public partial class Review4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Tb_Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Tb_Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tb_Country_CountryName",
                table: "Tb_Country");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Country_PhoneCode",
                table: "Tb_Country");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Tb_Person");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Tb_Person");
        }
    }
}
