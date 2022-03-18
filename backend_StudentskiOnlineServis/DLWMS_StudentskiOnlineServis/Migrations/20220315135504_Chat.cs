using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Chat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sadrzaj = table.Column<string>(nullable: true),
                    korisnik1_ID = table.Column<int>(nullable: false),
                    korisnik2_ID = table.Column<int>(nullable: false),
                    datumPoruke = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Poruke_KorisnickiNalog_korisnik1_ID",
                        column: x => x.korisnik1_ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poruke_KorisnickiNalog_korisnik2_ID",
                        column: x => x.korisnik2_ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_korisnik1_ID",
                table: "Poruke",
                column: "korisnik1_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_korisnik2_ID",
                table: "Poruke",
                column: "korisnik2_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poruke");
        }
    }
}
