using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conifs.rms.data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    PrivilegeCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivilegeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivilegeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.PrivilegeCode);
                });

            migrationBuilder.CreateTable(
                name: "RolePrivileges",
                columns: table => new
                {
                    RolePrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivilegeCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivileges", x => x.RolePrivilegeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Privileges");

            migrationBuilder.DropTable(
                name: "RolePrivileges");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
