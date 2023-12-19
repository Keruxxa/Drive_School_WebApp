using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedmarkcolumntoCartable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Cars",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Cars");
        }
    }
}
