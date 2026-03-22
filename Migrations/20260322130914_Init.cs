using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wprawka1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Czytelnicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KartaBiblioteczna = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czytelnicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydawcy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawcy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IDwydawcy = table.Column<int>(type: "int", nullable: false),
                    wydawcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Wydawcy_wydawcaId",
                        column: x => x.wydawcaId,
                        principalTable: "Wydawcy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDczytelnika = table.Column<int>(type: "int", nullable: false),
                    czytelnikId = table.Column<int>(type: "int", nullable: false),
                    IDksiazki = table.Column<int>(type: "int", nullable: false),
                    ksiazkaId = table.Column<int>(type: "int", nullable: false),
                    DataWypozyczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZwrotu = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Czytelnicy_czytelnikId",
                        column: x => x.czytelnikId,
                        principalTable: "Czytelnicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Ksiazki_ksiazkaId",
                        column: x => x.ksiazkaId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_wydawcaId",
                table: "Ksiazki",
                column: "wydawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_czytelnikId",
                table: "Wypozyczenia",
                column: "czytelnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_ksiazkaId",
                table: "Wypozyczenia",
                column: "ksiazkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wypozyczenia");

            migrationBuilder.DropTable(
                name: "Czytelnicy");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Wydawcy");
        }
    }
}
