using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using VibeQuestApp.Data;
using VibeQuestApp.Models;
using VibeQuestApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
    });

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10MB
});

builder.Services.AddScoped<OnboardingStateService>();

// Add EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity (basic User model)
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>();

// Custom services
builder.Services.AddScoped<QuestService>();
builder.Services.AddScoped<UserSessionService>();

var app = builder.Build();

// 🔧 Ensure /uploads is accessible as a static folder
app.UseStaticFiles(); // Required for wwwroot

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.WebRootPath, "uploads")),
    RequestPath = "/uploads"
});

// Seed database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    if (!db.Users.Any())
    {
        var testUser = new User
        {
            UserName = "test@example.com",
            Email = "test@example.com"
        };

        var result = await userManager.CreateAsync(testUser, "1234");

        if (result.Succeeded)
        {
            db.HeroProfiles.Add(new HeroProfile
            {
                UserId = testUser.Id,
                HeroName = "Test1",
                AvatarUrl = "/uploads/test.jpeg", // ✅ Must match a real file in wwwroot/uploads
                LifeFocusAreas = "Health, Creativity, Personal Development",
                PrimaryGoals = "test1",
                LongTermVision = "test2",
                MotivationStyle = "Rewards",
                CommitmentLevel = "Casual",
                DailyResetTime = TimeSpan.FromHours(4),
                Level = 1,
                CurrentXP = 0,
                TotalXP = 0
            });

            db.Quests.AddRange(
                new Quest
                {
                    UserId = testUser.Id,
                    Title = "Complete your first quest",
                    Description = "Mark this task as done to earn XP!",
                    XpReward = 50,
                    DueDate = DateTime.Today.AddDays(1),
                    IsCompleted = false
                },
                new Quest
                {
                    UserId = testUser.Id,
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
}

// Middleware pipeline
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
