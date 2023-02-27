using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class maticna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maticna",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    evidentiraoId = table.Column<int>(type: "int", nullable: false),
                    akademskaGodinaId = table.Column<int>(type: "int", nullable: false),
                    cijena = table.Column<float>(type: "real", nullable: false),
                    obnova = table.Column<bool>(type: "bit", nullable: false),
                    napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datumUpisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumOvjere = table.Column<DateTime>(type: "datetime2", nullable: true),
                    godina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maticna", x => x.id);
                    table.ForeignKey(
                        name: "FK_Maticna_AkademskaGodina_akademskaGodinaId",
                        column: x => x.akademskaGodinaId,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maticna_KorisnickiNalog_evidentiraoId",
                        column: x => x.evidentiraoId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maticna_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maticna_akademskaGodinaId",
                table: "Maticna",
                column: "akademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Maticna_evidentiraoId",
                table: "Maticna",
                column: "evidentiraoId");

            migrationBuilder.CreateIndex(
                name: "IX_Maticna_studentId",
                table: "Maticna",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maticna");
        }
    }
}
