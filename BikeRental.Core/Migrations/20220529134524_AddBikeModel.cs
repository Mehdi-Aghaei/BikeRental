using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddBikeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstHour = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    AdditionalHour = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PruchaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfLastService = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");
        }
    }
}
