using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Noleggi.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    Indirizzo = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Durata = table.Column<string>(type: "TEXT", nullable: false),
                    Giorno = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Risorse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Stato = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risorse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noleggi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    RisorsaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodicitaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CostoTeorico = table.Column<double>(type: "REAL", nullable: false),
                    CostoEffettivo = table.Column<double>(type: "REAL", nullable: false),
                    CostoTotale = table.Column<double>(type: "REAL", nullable: false),
                    DataRitiro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFineNoleggio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataConsegnaEffettiva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NomeNoleggio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noleggi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noleggi_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Noleggi_Periodi_PeriodicitaId",
                        column: x => x.PeriodicitaId,
                        principalTable: "Periodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Noleggi_Risorse_RisorsaId",
                        column: x => x.RisorsaId,
                        principalTable: "Risorse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriodicitaRisorse",
                columns: table => new
                {
                    PeriodicitaId = table.Column<int>(type: "INTEGER", nullable: false),
                    RisorsaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicitaRisorse", x => new { x.RisorsaId, x.PeriodicitaId });
                    table.ForeignKey(
                        name: "FK_PeriodicitaRisorse_Periodi_PeriodicitaId",
                        column: x => x.PeriodicitaId,
                        principalTable: "Periodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodicitaRisorse_Risorse_RisorsaId",
                        column: x => x.RisorsaId,
                        principalTable: "Risorse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clienti",
                columns: new[] { "Id", "Cognome", "DataNascita", "Email", "Indirizzo", "Nome", "Numero" },
                values: new object[,]
                {
                    { 1, "Perri", new DateTime(2005, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alessandro.perri@samtrevano.ch", "Via Boschina 2, Bedano", "Alessandro", "+41765545772" },
                    { 2, "Muniz", new DateTime(2004, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "diego.muniz@samtrevano.ch", "Via stazione, Quartino", "Diego", "+41765349425" },
                    { 3, "Ierardi", new DateTime(2005, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alex.ierardi@samtrevano.ch", "Via montagne, Biasca", "Alex", "+41794321432" },
                    { 4, "Monga", new DateTime(2005, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.monga@samtrevano.ch", "Via gerra, Bedano", "Christian", "+41791234567" },
                    { 5, "Ratti", new DateTime(2005, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "edoardo.ratti@samtrevano.ch", "Via cinquale, Caslano", "Edoardo", "+41795432100" }
                });

            migrationBuilder.InsertData(
                table: "Periodi",
                columns: new[] { "Id", "Durata", "Giorno" },
                values: new object[,]
                {
                    { 1, "Giornaliera", 1 },
                    { 2, "Settimanale", 7 },
                    { 3, "Mensile", 30 },
                    { 4, "Annuale", 360 }
                });

            migrationBuilder.InsertData(
                table: "Risorse",
                columns: new[] { "Id", "Categoria", "Nome", "Stato" },
                values: new object[,]
                {
                    { 1, "Informatica", "MacBook", "Disponibile" },
                    { 2, "Informatica", "Iphone 15", "Disponibile" },
                    { 3, "Elettrodomestici", "Aspirapolvere - Dyson", "Disponibile" },
                    { 4, "Elettrodomestici", "Friggitrice", "Disponibile" },
                    { 5, "Gaming", "Controller PS5", "Disponibile" }
                });

            migrationBuilder.InsertData(
                table: "PeriodicitaRisorse",
                columns: new[] { "PeriodicitaId", "RisorsaId", "Costo", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1.0, 1 },
                    { 2, 1, 10.0, 2 },
                    { 3, 1, 100.0, 3 },
                    { 4, 1, 1000.0, 4 },
                    { 1, 2, 2.0, 5 },
                    { 2, 2, 20.0, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noleggi_ClienteId",
                table: "Noleggi",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Noleggi_PeriodicitaId",
                table: "Noleggi",
                column: "PeriodicitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Noleggi_RisorsaId",
                table: "Noleggi",
                column: "RisorsaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicitaRisorse_PeriodicitaId",
                table: "PeriodicitaRisorse",
                column: "PeriodicitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noleggi");

            migrationBuilder.DropTable(
                name: "PeriodicitaRisorse");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Periodi");

            migrationBuilder.DropTable(
                name: "Risorse");
        }
    }
}
