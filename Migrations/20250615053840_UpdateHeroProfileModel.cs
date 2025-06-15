using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VibeQuestApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHeroProfileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeveloper",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeveloper",
                table: "AspNetUsers");
        }
    }
}
