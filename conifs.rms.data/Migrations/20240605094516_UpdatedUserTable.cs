using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conifs.rms.@base.api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Companies",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Companies",
                table: "GetUserDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "GetUserDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Companies",
                table: "GetUserDto");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "GetUserDto");

            migrationBuilder.AddColumn<string>(
                name: "Companies",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
