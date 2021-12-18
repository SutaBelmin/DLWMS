using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class AddStudentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog");

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    broj_indeksa = table.Column<string>(nullable: true),
                    datum_rodjenja = table.Column<DateTime>(nullable: true),
                    slika_studenta = table.Column<string>(nullable: true),
                    FakultetID = table.Column<int>(nullable: false),
                    KorisnickiNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.id);
                    table.ForeignKey(
                        name: "FK_Studenti_Fakulteti_FakultetID",
                        column: x => x.FakultetID,
                        principalTable: "Fakulteti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studenti_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_FakultetID",
                table: "Studenti",
                column: "FakultetID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KorisnickiNalogID",
                table: "Studenti",
                column: "KorisnickiNalogID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog",
                column: "FakultetID",
                principalTable: "Fakulteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog",
                column: "FakultetID",
                principalTable: "Fakulteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
