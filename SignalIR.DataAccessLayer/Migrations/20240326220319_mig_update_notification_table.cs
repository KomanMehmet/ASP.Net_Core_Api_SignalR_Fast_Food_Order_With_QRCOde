using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalIR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_notification_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificationIcon",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationIcon",
                table: "Notifications");
        }
    }
}
