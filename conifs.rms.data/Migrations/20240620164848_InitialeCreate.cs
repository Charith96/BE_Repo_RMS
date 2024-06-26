using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conifs.rms.data.Migrations
{
    /// <inheritdoc />
    public partial class InitialeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address01 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address02 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultCompany = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryID",
                table: "Companies",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CurrencyID",
                table: "Companies",
                column: "CurrencyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
