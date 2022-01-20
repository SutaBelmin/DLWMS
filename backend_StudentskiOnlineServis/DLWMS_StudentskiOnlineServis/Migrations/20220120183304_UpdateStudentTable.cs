using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class UpdateStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.AddColumn<DateTime>(
                name: "Student_DatumRodjenja",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Ime",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Prezime",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "broj_indeksa",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slika_studenta",
                table: "KorisnickiNalog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student_DatumRodjenja",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Student_Ime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Student_Prezime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "broj_indeksa",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "slika_studenta",
                table: "KorisnickiNalog");

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    broj_indeksa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slika_studenta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.id);
                    table.ForeignKey(
                        name: "FK_Studenti_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KorisnickiNalogID",
                table: "Studenti",
                column: "KorisnickiNalogID");
        }
    }
}
