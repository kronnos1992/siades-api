using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.PErsistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCountryCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneCode",
                table: "Tb_Country",
                newName: "CountryCode");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_Country_PhoneCode",
                table: "Tb_Country",
                newName: "IX_Tb_Country_CountryCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Tb_Country",
                newName: "PhoneCode");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_Country_CountryCode",
                table: "Tb_Country",
                newName: "IX_Tb_Country_PhoneCode");
        }
    }
}
