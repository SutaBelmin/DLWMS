using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Referent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Referent_Ime",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referent_Prezime",
                table: "KorisnickiNalog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Referent_Ime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Referent_Prezime",
                table: "KorisnickiNalog");
        }
    }
}
