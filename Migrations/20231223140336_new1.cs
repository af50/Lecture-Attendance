using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectureAttendance.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureAttendanceTime",
                table: "Attendances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LectureAttendanceTime",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
