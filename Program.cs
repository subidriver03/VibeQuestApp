using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using VibeQuestApp.Data;
using VibeQuestApp.Models;
using VibeQuestApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<LevelService>();
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

// Entity Framework Core with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();

// Custom services
builder.Services.AddScoped<QuestService>();
builder.Services.AddScoped<OnboardingStateService>();
builder.Services.AddScoped<RewardStoreService>();

var app = builder.Build();

// Serve static files including from /uploads
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.WebRootPath, "uploads")),
    RequestPath = "/uploads"
});

// Seed test data if needed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    db.Database.Migrate();

    if (!db.Users.Any())
    {
        var testUser = new User
        {
            UserName = "test@example.com",
            Email = "test@example.com"
        };

        await userManager.CreateAsync(testUser, "1234");

        db.HeroProfiles.Add(new HeroProfile
            {
                UserId = testUser.Id,
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

        var devUser = new User
        {
            UserName = "dev@example.com",
            Email = "dev@example.com",
            IsDeveloper = true
        };

        await userManager.CreateAsync(devUser, "dev1234");

        db.HeroProfiles.Add(new HeroProfile
        {
            UserId = devUser.Id,
            HeroName = "DevHero",
            AvatarUrl = "/uploads/test.jpeg",
            LifeFocusAreas = "All",
            PrimaryGoals = "Manage Users",
            LongTermVision = "Admin",
            MotivationStyle = "Rewards",
            CommitmentLevel = "Casual",
            DailyResetTime = TimeSpan.FromHours(4),
            Level = 1,
            CurrentXP = 0,
            TotalXP = 0
        });

        db.SaveChanges();
    }
}

// Configure middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
