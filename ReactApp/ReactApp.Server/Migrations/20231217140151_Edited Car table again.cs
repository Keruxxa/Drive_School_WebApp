using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Server.Migrations
{
    /// <inheritdoc />
    public partial class EditedCartableagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Students_StudentId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Teachers_TeacherId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Students_StudentId",
                table: "Cars",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Teachers_TeacherId",
                table: "Cars",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Students_StudentId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Teachers_TeacherId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Students_StudentId",
                table: "Cars",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Teachers_TeacherId",
                table: "Cars",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
