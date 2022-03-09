using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class roktestpitanjaodgovori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rokovi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorID = table.Column<int>(nullable: false),
                    Id_Predmet = table.Column<int>(nullable: false),
                    DatumOdrzavanja = table.Column<DateTime>(nullable: false),
                    NazivTesta = table.Column<string>(nullable: true),
                    BrojPitanja = table.Column<int>(nullable: true),
                    Aktivan = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rokovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rokovi_Predmet_Id_Predmet",
                        column: x => x.Id_Predmet,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rokovi_KorisnickiNalog_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pitanja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Indeks = table.Column<int>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: true),
                    RokID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pitanja_Rokovi_RokID",
                        column: x => x.RokID,
                        principalTable: "Rokovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odgovori",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SadrzajOdgovora = table.Column<string>(nullable: true),
                    Tacan = table.Column<bool>(nullable: false),
                    PitanjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odgovori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Odgovori_Pitanja_PitanjeID",
                        column: x => x.PitanjeID,
                        principalTable: "Pitanja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odgovori_PitanjeID",
                table: "Odgovori",
                column: "PitanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanja_RokID",
                table: "Pitanja",
                column: "RokID");

            migrationBuilder.CreateIndex(
                name: "IX_Rokovi_Id_Predmet",
                table: "Rokovi",
                column: "Id_Predmet");

            migrationBuilder.CreateIndex(
                name: "IX_Rokovi_ProfesorID",
                table: "Rokovi",
                column: "ProfesorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odgovori");

            migrationBuilder.DropTable(
                name: "Pitanja");

            migrationBuilder.DropTable(
                name: "Rokovi");
        }
    }
}
