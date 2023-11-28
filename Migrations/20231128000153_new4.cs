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
                name: "FK_enrollments_courses_CoursesCId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_students_StudentsId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_instructorsStudents_instructors_InstructorsId",
                table: "instructorsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_instructorsStudents_students_StudentsId",
                table: "instructorsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_courses_CoursesCId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_instructors_InstructorsId",
                table: "Lectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructorsStudents",
                table: "instructorsStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructors",
                table: "instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "instructorsStudents",
                newName: "InstructorsStudents");

            migrationBuilder.RenameTable(
                name: "instructors",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "enrollments",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_instructorsStudents_StudentsId",
                table: "InstructorsStudents",
                newName: "IX_InstructorsStudents_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_instructorsStudents_InstructorsId",
                table: "InstructorsStudents",
                newName: "IX_InstructorsStudents_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_StudentsId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_CoursesCId",
                table: "Enrollments",
                newName: "IX_Enrollments_CoursesCId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorsStudents",
                table: "InstructorsStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CoursesCId",
                table: "Enrollments",
                column: "CoursesCId",
                principalTable: "Courses",
                principalColumn: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentsId",
                table: "Enrollments",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorsStudents_Instructors_InstructorsId",
                table: "InstructorsStudents",
                column: "InstructorsId",
                principalTable: "Instructors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorsStudents_Students_StudentsId",
                table: "InstructorsStudents",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CoursesCId",
                table: "Lectures",
                column: "CoursesCId",
                principalTable: "Courses",
                principalColumn: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Instructors_InstructorsId",
                table: "Lectures",
                column: "InstructorsId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CoursesCId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentsId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorsStudents_Instructors_InstructorsId",
                table: "InstructorsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorsStudents_Students_StudentsId",
                table: "InstructorsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CoursesCId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Instructors_InstructorsId",
                table: "Lectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorsStudents",
                table: "InstructorsStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.RenameTable(
                name: "InstructorsStudents",
                newName: "instructorsStudents");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "instructors");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "enrollments");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "courses");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorsStudents_StudentsId",
                table: "instructorsStudents",
                newName: "IX_instructorsStudents_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorsStudents_InstructorsId",
                table: "instructorsStudents",
                newName: "IX_instructorsStudents_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentsId",
                table: "enrollments",
                newName: "IX_enrollments_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CoursesCId",
                table: "enrollments",
                newName: "IX_enrollments_CoursesCId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructorsStudents",
                table: "instructorsStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructors",
                table: "instructors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_courses_CoursesCId",
                table: "enrollments",
                column: "CoursesCId",
                principalTable: "courses",
                principalColumn: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_students_StudentsId",
                table: "enrollments",
                column: "StudentsId",
                principalTable: "students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructorsStudents_instructors_InstructorsId",
                table: "instructorsStudents",
                column: "InstructorsId",
                principalTable: "instructors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructorsStudents_students_StudentsId",
                table: "instructorsStudents",
                column: "StudentsId",
                principalTable: "students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_courses_CoursesCId",
                table: "Lectures",
                column: "CoursesCId",
                principalTable: "courses",
                principalColumn: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_instructors_InstructorsId",
                table: "Lectures",
                column: "InstructorsId",
                principalTable: "instructors",
                principalColumn: "Id");
        }
    }
}
