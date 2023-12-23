using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectureAttendance.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Attendances",
                newName: "LectureStartTime");

            migrationBuilder.RenameColumn(
                name: "DateOfLecture",
                table: "Attendances",
                newName: "LectureDate");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Attendances",
                newName: "LectureLocation");

            migrationBuilder.AddColumn<string>(
                name: "LectureAttendanceTime",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureAttendanceTime",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "LectureStartTime",
                table: "Attendances",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "LectureDate",
                table: "Attendances",
                newName: "DateOfLecture");

            migrationBuilder.RenameColumn(
                name: "LectureLocation",
                table: "Attendances",
                newName: "Location");
        }
    }
}
