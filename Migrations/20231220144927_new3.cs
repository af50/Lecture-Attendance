using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectureAttendance.Migrations
{
    /// <inheritdoc />
    public partial class new3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Lectures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Lectures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures",
                columns: new[] { "Location", "DateOfLecture", "StartTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures",
                columns: new[] { "CourseId", "InstructorId", "DateOfLecture" });
        }
    }
}
