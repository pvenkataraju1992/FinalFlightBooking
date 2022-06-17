using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FBS.Service.Inventory.Api.Migrations
{
    public partial class initialairlinemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    AirlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineName = table.Column<string>(nullable: true),
                    AirlineLogo = table.Column<string>(nullable: true),
                    AirlineContactNumber = table.Column<string>(nullable: true),
                    AirlineContactAddress = table.Column<string>(nullable: true),
                    IsInventory = table.Column<bool>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.AirlineId);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightNumber = table.Column<string>(nullable: true),
                    AirlineId = table.Column<int>(nullable: false),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ScheduledDays = table.Column<string>(nullable: true),
                    InstumentUsed = table.Column<string>(nullable: true),
                    NoOfBusinessClassSeats = table.Column<int>(nullable: false),
                    NoOfNonBusinessClassSeats = table.Column<int>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    NumberOfRows = table.Column<int>(nullable: false),
                    MealType = table.Column<string>(nullable: true),
                    OneWay = table.Column<bool>(nullable: false),
                    TwoWay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "AirlineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_AirlineId",
                table: "Inventories",
                column: "AirlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Airlines");
        }
    }
}
