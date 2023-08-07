using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence
{
    /// <inheritdoc />
    public partial class Review2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "Tb_BloodRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Tb_BloodRequest");
        }
    }
}
