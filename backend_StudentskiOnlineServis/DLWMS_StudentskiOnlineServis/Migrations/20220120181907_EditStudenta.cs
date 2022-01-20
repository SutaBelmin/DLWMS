using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class EditStudenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Studenti",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Studenti",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KorisnickiNalogID",
                table: "Studenti",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Studenti",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KorisnickiNalogID",
                table: "Studenti",
                column: "KorisnickiNalogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_KorisnickiNalog_KorisnickiNalogID",
                table: "Studenti",
                column: "KorisnickiNalogID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_KorisnickiNalog_KorisnickiNalogID",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_KorisnickiNalogID",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "KorisnickiNalogID",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Studenti");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Studenti",
                type: "int",
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
    }
}
