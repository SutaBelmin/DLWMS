using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class Predmet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<int>(nullable: false),
                    Oznaka = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor_Predmet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profesorId = table.Column<int>(nullable: false),
                    predmetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor_Predmet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_Predmet_Predmet_predmetId",
                        column: x => x.predmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesor_Predmet_KorisnickiNalog_profesorId",
                        column: x => x.profesorId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student_Predmet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(nullable: false),
                    predmetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Predmet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Predmet_Predmet_predmetId",
                        column: x => x.predmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Predmet_KorisnickiNalog_studentId",
                        column: x => x.studentId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Predmet_predmetId",
                table: "Profesor_Predmet",
                column: "predmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Predmet_profesorId",
                table: "Profesor_Predmet",
                column: "profesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Predmet_predmetId",
                table: "Student_Predmet",
                column: "predmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Predmet_studentId",
                table: "Student_Predmet",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profesor_Predmet");

            migrationBuilder.DropTable(
                name: "Student_Predmet");

            migrationBuilder.DropTable(
                name: "Predmet");
        }
    }
}
