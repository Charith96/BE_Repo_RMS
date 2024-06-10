using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conifs.rms.data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerCode);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ReservationItems_groupId",
                table: "ReservationItems",
                column: "groupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ReservationItems");

            migrationBuilder.DropTable(
                name: "ReservationGroups");
        }
    }
}
