using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Pot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SvrhaPotvrde",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SvrhaPotvrde", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Potvrda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(nullable: false),
                    referentId = table.Column<int>(nullable: false),
                    Izdata = table.Column<bool>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    svrhaId = table.Column<int>(nullable: false),
                    datum_izdavanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potvrda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Potvrda_KorisnickiNalog_referentId",
                        column: x => x.referentId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Potvrda_KorisnickiNalog_studentId",
                        column: x => x.studentId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Potvrda_SvrhaPotvrde_svrhaId",
                        column: x => x.svrhaId,
                        principalTable: "SvrhaPotvrde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Potvrda_referentId",
                table: "Potvrda",
                column: "referentId");

            migrationBuilder.CreateIndex(
                name: "IX_Potvrda_studentId",
                table: "Potvrda",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Potvrda_svrhaId",
                table: "Potvrda",
                column: "svrhaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Potvrda");

            migrationBuilder.DropTable(
                name: "SvrhaPotvrde");
        }
    }
}
