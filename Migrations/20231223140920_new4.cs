using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectureAttendance.Migrations
{
    /// <inheritdoc />
    public partial class new4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Lectures_LecturesLocation_LecturesDateOfLecture_LecturesStartTime",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "LecturesDate",
                table: "Attendances");

            migrationBuilder.AlterColumn<string>(
                name: "LecturesDateOfLecture",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                columns: new[] { "StudentID", "LecturesLocation", "LecturesDateOfLecture", "LecturesStartTime" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Lectures_LecturesLocation_LecturesDateOfLecture_LecturesStartTime",
                table: "Attendances",
                columns: new[] { "LecturesLocation", "LecturesDateOfLecture", "LecturesStartTime" },
                principalTable: "Lectures",
                principalColumns: new[] { "Location", "DateOfLecture", "StartTime" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Lectures_LecturesLocation_LecturesDateOfLecture_LecturesStartTime",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.AlterColumn<string>(
                name: "LecturesDateOfLecture",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "LecturesDate",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                columns: new[] { "StudentID", "LecturesLocation", "LecturesDate", "LecturesStartTime" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Lectures_LecturesLocation_LecturesDateOfLecture_LecturesStartTime",
                table: "Attendances",
                columns: new[] { "LecturesLocation", "LecturesDateOfLecture", "LecturesStartTime" },
                principalTable: "Lectures",
                principalColumns: new[] { "Location", "DateOfLecture", "StartTime" });
        }
    }
}
