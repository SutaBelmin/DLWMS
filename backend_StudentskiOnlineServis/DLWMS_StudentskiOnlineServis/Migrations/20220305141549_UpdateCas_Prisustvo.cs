using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class UpdateCas_Prisustvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfesorID",
                table: "Casovi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_ProfesorID",
                table: "Casovi",
                column: "ProfesorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Casovi_KorisnickiNalog_ProfesorID",
                table: "Casovi",
                column: "ProfesorID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casovi_KorisnickiNalog_ProfesorID",
                table: "Casovi");

            migrationBuilder.DropIndex(
                name: "IX_Casovi_ProfesorID",
                table: "Casovi");

            migrationBuilder.DropColumn(
                name: "ProfesorID",
                table: "Casovi");
        }
    }
}
