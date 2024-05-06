using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conifs.rms.@base.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationGroups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    groupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationGroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DefaultCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PrimaryRole = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTill = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "ReservationItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timeSlotType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slotDurationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    durationPerSlot = table.Column<int>(type: "int", nullable: false),
                    noOfSlots = table.Column<int>(type: "int", nullable: false),
                    noOfReservations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    groupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReservationItems_ReservationGroups_groupId",
                        column: x => x.groupId,
                        principalTable: "ReservationGroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompany",
                columns: table => new
                {
                    UserCompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany", x => x.UserCompanyID);
                    table.ForeignKey(
                        name: "FK_UserCompany_User_UserCode",
                        column: x => x.UserCode,
                        principalTable: "User",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationItems_groupId",
                table: "ReservationItems",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_UserCode",
                table: "UserCompany",
                column: "UserCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationItems");

            migrationBuilder.DropTable(
                name: "UserCompany");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "ReservationGroups");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
