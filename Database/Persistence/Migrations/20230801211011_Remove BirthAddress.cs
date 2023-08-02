using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siades.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBirthAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_BirthAddress_Tb_TownShiep_TownShiepId",
                table: "Tb_BirthAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Person_Tb_BirthAddress_BirthAddressId",
                table: "Tb_Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_BirthAddress",
                table: "Tb_BirthAddress");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Tb_Doctor");

            migrationBuilder.RenameTable(
                name: "Tb_BirthAddress",
                newName: "BirthAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_BirthAddress_TownShiepId",
                table: "BirthAddress",
                newName: "IX_BirthAddress_TownShiepId");

            migrationBuilder.AddColumn<string>(
                name: "BirthAddress",
                table: "Tb_Person",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BirthAddress",
                table: "BirthAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthAddress_Tb_TownShiep_TownShiepId",
                table: "BirthAddress",
                column: "TownShiepId",
                principalTable: "Tb_TownShiep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Person_BirthAddress_BirthAddressId",
                table: "Tb_Person",
                column: "BirthAddressId",
                principalTable: "BirthAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthAddress_Tb_TownShiep_TownShiepId",
                table: "BirthAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Person_BirthAddress_BirthAddressId",
                table: "Tb_Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BirthAddress",
                table: "BirthAddress");

            migrationBuilder.DropColumn(
                name: "BirthAddress",
                table: "Tb_Person");

            migrationBuilder.RenameTable(
                name: "BirthAddress",
                newName: "Tb_BirthAddress");

            migrationBuilder.RenameIndex(
                name: "IX_BirthAddress_TownShiepId",
                table: "Tb_BirthAddress",
                newName: "IX_Tb_BirthAddress_TownShiepId");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialityId",
                table: "Tb_Doctor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_BirthAddress",
                table: "Tb_BirthAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_BirthAddress_Tb_TownShiep_TownShiepId",
                table: "Tb_BirthAddress",
                column: "TownShiepId",
                principalTable: "Tb_TownShiep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Person_Tb_BirthAddress_BirthAddressId",
                table: "Tb_Person",
                column: "BirthAddressId",
                principalTable: "Tb_BirthAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
