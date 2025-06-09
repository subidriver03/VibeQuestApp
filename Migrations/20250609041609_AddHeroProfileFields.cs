using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VibeQuestApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroProfileFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommitmentLevel",
                table: "HeroProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DailyResetTime",
                table: "HeroProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "LifeFocusAreas",
                table: "HeroProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongTermVision",
                table: "HeroProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotivationStyle",
                table: "HeroProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryGoals",
                table: "HeroProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommitmentLevel",
                table: "HeroProfiles");

            migrationBuilder.DropColumn(
                name: "DailyResetTime",
                table: "HeroProfiles");

            migrationBuilder.DropColumn(
                name: "LifeFocusAreas",
                table: "HeroProfiles");

            migrationBuilder.DropColumn(
                name: "LongTermVision",
                table: "HeroProfiles");

            migrationBuilder.DropColumn(
                name: "MotivationStyle",
                table: "HeroProfiles");

            migrationBuilder.DropColumn(
                name: "PrimaryGoals",
                table: "HeroProfiles");
        }
    }
}
