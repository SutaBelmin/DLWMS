using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Cas_Prisustvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casovi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    Lekcija = table.Column<string>(nullable: true),
                    PredmetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Casovi_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prisustva",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisustva", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prisustva_Casovi_CasID",
                        column: x => x.CasID,
                        principalTable: "Casovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prisustva_KorisnickiNalog_StudentID",
                        column: x => x.StudentID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_PredmetID",
                table: "Casovi",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Prisustva_CasID",
                table: "Prisustva",
                column: "CasID");

            migrationBuilder.CreateIndex(
                name: "IX_Prisustva_StudentID",
                table: "Prisustva",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prisustva");

            migrationBuilder.DropTable(
                name: "Casovi");
        }
    }
}
