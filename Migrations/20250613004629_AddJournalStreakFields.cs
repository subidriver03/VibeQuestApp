﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VibeQuestApp.Migrations
{
    /// <inheritdoc />
    public partial class AddJournalStreakFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JournalStreak",
                table: "HeroProfiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastJournalEntryDate",
                table: "HeroProfiles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JournalStreak",
                table: "HeroProfiles");

            migrationBuilder.DropColumn(
                name: "LastJournalEntryDate",
                table: "HeroProfiles");
        }
    }
}
