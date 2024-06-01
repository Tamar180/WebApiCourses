using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Data.Migrations
{
    public partial class Mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePupil");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "PupilsId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CoursePupilDto",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    PupilsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePupilDto", x => new { x.CoursesId, x.PupilsId });
                    table.ForeignKey(
                        name: "FK_CoursePupilDto_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePupilDto_Pupils_PupilsId",
                        column: x => x.PupilsId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePupilDto_PupilsId",
                table: "CoursePupilDto",
                column: "PupilsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePupilDto");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Pupils",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PupilsId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CoursePupil",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    PupilsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePupil", x => new { x.CoursesId, x.PupilsId });
                    table.ForeignKey(
                        name: "FK_CoursePupil_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePupil_Pupils_PupilsId",
                        column: x => x.PupilsId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePupil_PupilsId",
                table: "CoursePupil",
                column: "PupilsId");
        }
    }
}
