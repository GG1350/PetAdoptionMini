using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionMini.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create_with_all_the_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Pets",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<Guid>(
                name: "AdopterId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PetSpeciesId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Adopters",
                columns: table => new
                {
                    AdopterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopters", x => x.AdopterId);
                });

            migrationBuilder.CreateTable(
                name: "PetSpecies",
                columns: table => new
                {
                    PetSpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetSpecies", x => x.PetSpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    ShelterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Settlement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.ShelterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AdopterId",
                table: "Pets",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetSpeciesId",
                table: "Pets",
                column: "PetSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ShelterId",
                table: "Pets",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Adopters_Email",
                table: "Adopters",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetSpecies_Name",
                table: "PetSpecies",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Adopters_AdopterId",
                table: "Pets",
                column: "AdopterId",
                principalTable: "Adopters",
                principalColumn: "AdopterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetSpecies_PetSpeciesId",
                table: "Pets",
                column: "PetSpeciesId",
                principalTable: "PetSpecies",
                principalColumn: "PetSpeciesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Shelters_ShelterId",
                table: "Pets",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "ShelterId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Adopters_AdopterId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetSpecies_PetSpeciesId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Shelters_ShelterId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Adopters");

            migrationBuilder.DropTable(
                name: "PetSpecies");

            migrationBuilder.DropTable(
                name: "Shelters");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AdopterId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetSpeciesId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ShelterId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "AdopterId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetSpeciesId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Pets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);
        }
    }
}
