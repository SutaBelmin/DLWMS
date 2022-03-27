using Microsoft.EntityFrameworkCore.Migrations;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    public partial class StudentRok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdgovoriNaPitanja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RokID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    OdgovorID = table.Column<int>(nullable: false),
                    StudentZaokruzio = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdgovoriNaPitanja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OdgovoriNaPitanja_Odgovori_OdgovorID",
                        column: x => x.OdgovorID,
                        principalTable: "Odgovori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdgovoriNaPitanja_Rokovi_RokID",
                        column: x => x.RokID,
                        principalTable: "Rokovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdgovoriNaPitanja_KorisnickiNalog_StudentID",
                        column: x => x.StudentID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdgovoriNaPitanja_OdgovorID",
                table: "OdgovoriNaPitanja",
                column: "OdgovorID");

            migrationBuilder.CreateIndex(
                name: "IX_OdgovoriNaPitanja_RokID",
                table: "OdgovoriNaPitanja",
                column: "RokID");

            migrationBuilder.CreateIndex(
                name: "IX_OdgovoriNaPitanja_StudentID",
                table: "OdgovoriNaPitanja",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdgovoriNaPitanja");
        }
    }
}
