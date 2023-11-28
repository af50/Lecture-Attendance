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
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "students",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrcutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentsId = table.Column<int>(type: "int", nullable: true),
                    CoursesCId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enrollments_courses_CoursesCId",
                        column: x => x.CoursesCId,
                        principalTable: "courses",
                        principalColumn: "CId");
                    table.ForeignKey(
                        name: "FK_enrollments_students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "instructorsStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsId = table.Column<int>(type: "int", nullable: true),
                    InstructorsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructorsStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_instructorsStudents_instructors_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "instructors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_instructorsStudents_students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfLecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorsId = table.Column<int>(type: "int", nullable: true),
                    CoursesCId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LId);
                    table.ForeignKey(
                        name: "FK_Lectures_courses_CoursesCId",
                        column: x => x.CoursesCId,
                        principalTable: "courses",
                        principalColumn: "CId");
                    table.ForeignKey(
                        name: "FK_Lectures_instructors_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_CoursesCId",
                table: "enrollments",
                column: "CoursesCId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_StudentsId",
                table: "enrollments",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_instructorsStudents_InstructorsId",
                table: "instructorsStudents",
                column: "InstructorsId");

            migrationBuilder.CreateIndex(
                name: "IX_instructorsStudents_StudentsId",
                table: "instructorsStudents",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CoursesCId",
                table: "Lectures",
                column: "CoursesCId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_InstructorsId",
                table: "Lectures",
                column: "InstructorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "instructorsStudents");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
