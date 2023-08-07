using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence
{
    /// <inheritdoc />
    public partial class Review3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Tb_BloodRequest",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Tb_BloodRequest");
        }
    }
}
