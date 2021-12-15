using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Autentifikacija_Verifikacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Fakultet_FakultetID",
                table: "Korisnici");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fakultet",
                table: "Fakultet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici");

            migrationBuilder.RenameTable(
                name: "Fakultet",
                newName: "Fakulteti");

            migrationBuilder.RenameTable(
                name: "Korisnici",
                newName: "KorisnickiNalog");

            migrationBuilder.RenameIndex(
                name: "IX_Korisnici_FakultetID",
                table: "KorisnickiNalog",
                newName: "IX_KorisnickiNalog_FakultetID");

            migrationBuilder.AlterColumn<int>(
                name: "Vrsta_Korisnika",
                table: "KorisnickiNalog",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FakultetID",
                table: "KorisnickiNalog",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumRodjenja",
                table: "KorisnickiNalog",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumPrijave",
                table: "KorisnickiNalog",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "KorisnickiNalog",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fakulteti",
                table: "Fakulteti",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnickiNalog",
                table: "KorisnickiNalog",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false),
                    IP_Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verifikacije",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifikacije", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog",
                column: "FakultetID",
                principalTable: "Fakulteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "Verifikacije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fakulteti",
                table: "Fakulteti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnickiNalog",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "KorisnickiNalog");

            migrationBuilder.RenameTable(
                name: "Fakulteti",
                newName: "Fakultet");

            migrationBuilder.RenameTable(
                name: "KorisnickiNalog",
                newName: "Korisnici");

            migrationBuilder.RenameIndex(
                name: "IX_KorisnickiNalog_FakultetID",
                table: "Korisnici",
                newName: "IX_Korisnici_FakultetID");

            migrationBuilder.AlterColumn<int>(
                name: "Vrsta_Korisnika",
                table: "Korisnici",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FakultetID",
                table: "Korisnici",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Korisnici",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumPrijave",
                table: "Korisnici",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fakultet",
                table: "Fakultet",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Fakultet_FakultetID",
                table: "Korisnici",
                column: "FakultetID",
                principalTable: "Fakultet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
