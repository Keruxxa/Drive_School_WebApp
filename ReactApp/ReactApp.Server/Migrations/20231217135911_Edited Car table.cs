using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Server.Migrations
{
    /// <inheritdoc />
    public partial class EditedCartable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Students_StudentId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Teachers_TeacherId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_TeacherId",
                table: "Reviews",
                newName: "IX_Reviews_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_StudentId",
                table: "Reviews",
                newName: "IX_Reviews_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Students_StudentId",
                table: "Reviews",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Teachers_TeacherId",
                table: "Reviews",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Students_StudentId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Teachers_TeacherId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_TeacherId",
                table: "Ratings",
                newName: "IX_Ratings_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_StudentId",
                table: "Ratings",
                newName: "IX_Ratings_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Students_StudentId",
                table: "Ratings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Teachers_TeacherId",
                table: "Ratings",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
