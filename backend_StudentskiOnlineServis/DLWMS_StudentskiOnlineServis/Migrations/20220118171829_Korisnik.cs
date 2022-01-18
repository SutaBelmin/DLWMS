using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Korisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Fakulteti_FakultetID",
                table: "Studenti");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_KorisnickiNalog_KorisnickiNalogID",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_FakultetID",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_KorisnickiNalogID",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "FakultetID",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "KorisnickiNalogID",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "datum_rodjenja",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "Studenti");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Studenti",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KorisnikID",
                table: "Studenti",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_KorisnickiNalog_KorisnikID",
                table: "Studenti",
                column: "KorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_KorisnickiNalog_KorisnikID",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_KorisnikID",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Studenti");

            migrationBuilder.AddColumn<int>(
                name: "FakultetID",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KorisnickiNalogID",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "datum_rodjenja",
                table: "Studenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Studenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "Studenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_FakultetID",
                table: "Studenti",
                column: "FakultetID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KorisnickiNalogID",
                table: "Studenti",
                column: "KorisnickiNalogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Fakulteti_FakultetID",
                table: "Studenti",
                column: "FakultetID",
                principalTable: "Fakulteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_KorisnickiNalog_KorisnickiNalogID",
                table: "Studenti",
                column: "KorisnickiNalogID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
