using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainAPI.Migrations
{
    /// <inheritdoc />
    public partial class BookingUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "bookings",
                newName: "SeatCapacity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatCapacity",
                table: "bookings",
                newName: "Capacity");
        }
    }
}
