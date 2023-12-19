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
                name: "Time",
                table: "Lectures",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Lectures",
                newName: "EndTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Lectures",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Lectures",
                newName: "Duration");
        }
    }
}
