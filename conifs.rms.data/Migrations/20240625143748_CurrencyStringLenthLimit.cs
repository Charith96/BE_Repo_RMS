using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conifs.rms.data.Migrations
{
    /// <inheritdoc />
    public partial class CurrencyStringLenthLimit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrencyName",
                table: "Currencies",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrencyName",
                table: "Currencies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);
        }
    }
}
