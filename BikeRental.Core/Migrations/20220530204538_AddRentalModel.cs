using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RentalEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");
        }
    }
}
