﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartVet.Migrations
{
    public partial class AnimalBreedModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalBreeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalBreeds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalBreeds_Name",
                table: "AnimalBreeds",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalBreeds");
        }
    }
}
