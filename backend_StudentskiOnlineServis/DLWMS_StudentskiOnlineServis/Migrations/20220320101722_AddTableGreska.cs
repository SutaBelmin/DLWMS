using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class AddTableGreska : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Admin_Ime",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_Prezime",
                table: "KorisnickiNalog",
                nullable: true);


            migrationBuilder.CreateTable(
                name: "Greska",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    Datum_prijave = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greska", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Greska");

            migrationBuilder.DropColumn(
                name: "Admin_Ime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Admin_Prezime",
                table: "KorisnickiNalog");
        }
    }
}
