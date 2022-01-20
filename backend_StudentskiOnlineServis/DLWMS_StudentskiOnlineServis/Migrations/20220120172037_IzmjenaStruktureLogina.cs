using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class IzmjenaStruktureLogina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FakultetID",
                table: "KorisnickiNalog",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FakultetEmail",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivatniEmail",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "KorisnickiNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Profesor_Ime",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profesor_Prezime",
                table: "KorisnickiNalog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FakultetEmail",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "PrivatniEmail",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Profesor_Ime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Profesor_Prezime",
                table: "KorisnickiNalog");

            migrationBuilder.AlterColumn<int>(
                name: "FakultetID",
                table: "KorisnickiNalog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
