using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Usp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uspjeh",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_predmetId = table.Column<int>(nullable: false),
                    profesor_predmetId = table.Column<int>(nullable: false),
                    ocjena = table.Column<int>(nullable: false),
                    datum_upisa = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uspjeh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uspjeh_Profesor_Predmet_profesor_predmetId",
                        column: x => x.profesor_predmetId,
                        principalTable: "Profesor_Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uspjeh_Student_Predmet_student_predmetId",
                        column: x => x.student_predmetId,
                        principalTable: "Student_Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uspjeh_profesor_predmetId",
                table: "Uspjeh",
                column: "profesor_predmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Uspjeh_student_predmetId",
                table: "Uspjeh",
                column: "student_predmetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uspjeh");
        }
    }
}
