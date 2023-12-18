using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Server.Migrations
{
    /// <inheritdoc />
    public partial class RenamedRatingtabletoReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Student_StudentId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Student_StudentId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Groups_GroupId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_PracticalExams_PracticalExamId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_TheoryExams_TheoryExamId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_TheoryExamId",
                table: "Students",
                newName: "IX_Students_TheoryExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_PracticalExamId",
                table: "Students",
                newName: "IX_Students_PracticalExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GroupId",
                table: "Students",
                newName: "IX_Students_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Students_StudentId",
                table: "Cars",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Students_StudentId",
                table: "Ratings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_PracticalExams_PracticalExamId",
                table: "Students",
                column: "PracticalExamId",
                principalTable: "PracticalExams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_TheoryExams_TheoryExamId",
                table: "Students",
                column: "TheoryExamId",
                principalTable: "TheoryExams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Students_StudentId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Students_StudentId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_PracticalExams_PracticalExamId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_TheoryExams_TheoryExamId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_TheoryExamId",
                table: "Student",
                newName: "IX_Student_TheoryExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_PracticalExamId",
                table: "Student",
                newName: "IX_Student_PracticalExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GroupId",
                table: "Student",
                newName: "IX_Student_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Student_StudentId",
                table: "Cars",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Student_StudentId",
                table: "Ratings",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Groups_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_PracticalExams_PracticalExamId",
                table: "Student",
                column: "PracticalExamId",
                principalTable: "PracticalExams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_TheoryExams_TheoryExamId",
                table: "Student",
                column: "TheoryExamId",
                principalTable: "TheoryExams",
                principalColumn: "Id");
        }
    }
}
