using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Data.Migrations
{
    public partial class ef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectures_lectureId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "lectureId",
                table: "Courses",
                newName: "LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_lectureId",
                table: "Courses",
                newName: "IX_Courses_LectureId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectures_LectureId",
                table: "Courses",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectures_LectureId",
                table: "Courses");

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

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Courses",
                newName: "lectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_LectureId",
                table: "Courses",
                newName: "IX_Courses_lectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectures_lectureId",
                table: "Courses",
                column: "lectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
