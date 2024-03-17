using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalIR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_socialMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SocialMediaTitle",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaUrl",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialMediaTitle",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "SocialMediaUrl",
                table: "SocialMedias");
        }
    }
}
