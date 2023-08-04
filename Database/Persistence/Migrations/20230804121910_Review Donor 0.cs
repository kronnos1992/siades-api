﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReviewDonor0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsElegilbe",
                table: "Tb_Donor",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsElegilbe",
                table: "Tb_Donor");
        }
    }
}
