﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence
{
    /// <inheritdoc />
    public partial class Review6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tb_Doctor_BloodGroupName",
                table: "Tb_Doctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tb_Doctor_BloodGroupName",
                table: "Tb_Doctor",
                column: "BloodGroupName",
                unique: true);
        }
    }
}
