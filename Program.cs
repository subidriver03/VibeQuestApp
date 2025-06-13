using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Data;
using VibeQuestApp.Models;
using VibeQuestApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB for SignalR
    });

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10MB for file uploads
});

builder.Services.AddScoped<QuestService>();
builder.Services.AddScoped<UserSessionService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Users.Any())
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword("1234");
        var user = new User
        {
            Email = "test@example.com",
            PasswordHash = hashedPassword
        };

        db.Users.Add(user);
        db.SaveChanges();

        var heroProfile = new HeroProfile
        {
            UserId = user.Id,
            HeroName = "Test1",
            AvatarUrl = "/uploads/test.jpeg",
            LifeFocusAreas = "Health, Creativity, Personal Development",
            PrimaryGoals = "test1",
            LongTermVision = "test2",
            MotivationStyle = "Rewards",
            CommitmentLevel = "Casual",
            DailyResetTime = TimeSpan.FromHours(4),
            Level = 1,
            CurrentXP = 0,
            TotalXP = 0
        };

        db.HeroProfiles.Add(heroProfile);

        // Seed a couple of quests
        db.Quests.AddRange(
            new Quest
            {
                UserId = user.Id,
                Title = "Complete your first quest",
                Description = "Mark this task as done to earn XP!",
                XpReward = 50,
                DueDate = DateTime.Today.AddDays(1),
                IsCompleted = false
            },
            new Quest
            {
                UserId = user.Id,
                Title = "Check your profile",
                Description = "Make sure your hero info is filled out.",
                XpReward = 30,
                DueDate = DateTime.Today.AddDays(2),
                IsCompleted = false
            }
        );

        db.SaveChanges();
    }
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
