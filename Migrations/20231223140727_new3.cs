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
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "LectureLocation",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "LectureDate",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "LectureStartTime",
                table: "Attendances",
                newName: "LecturesDate");

            migrationBuilder.AlterColumn<string>(
                name: "LecturesStartTime",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LecturesLocation",
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
                columns: new[] { "StudentID", "LecturesLocation", "LecturesDate", "LecturesStartTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "LecturesDate",
                table: "Attendances",
                newName: "LectureStartTime");

            migrationBuilder.AlterColumn<string>(
                name: "LecturesStartTime",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LecturesLocation",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "LectureLocation",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LectureDate",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                columns: new[] { "StudentID", "LectureLocation", "LectureDate", "LectureStartTime" });
        }
    }
}
