﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VibeQuestApp.Data;

#nullable disable

namespace VibeQuestApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250613004629_AddJournalStreakFields")]
    partial class AddJournalStreakFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("VibeQuestApp.Models.HeroProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CommitmentLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentXP")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("DailyResetTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("JournalStreak")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastJournalEntryDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LifeFocusAreas")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LongTermVision")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MotivationStyle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimaryGoals")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalXP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HeroProfiles");
                });

            modelBuilder.Entity("VibeQuestApp.Models.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mood")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("VibeQuestApp.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Priority")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XpReward")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("VibeQuestApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VibeQuestApp.Models.HeroProfile", b =>
                {
                    b.HasOne("VibeQuestApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
