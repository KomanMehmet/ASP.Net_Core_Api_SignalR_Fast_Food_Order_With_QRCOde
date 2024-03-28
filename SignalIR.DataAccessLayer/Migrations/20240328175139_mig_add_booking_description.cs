using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalIR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_booking_description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationDescription",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationDescription",
                table: "Bookings");
        }
    }
}
