using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Data;
using VibeQuestApp.Models;
using VibeQuestApp.Services;


var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<QuestService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Use Scoped for per-user session management
builder.Services.AddScoped<UserSessionService>();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // Creates DB if not exists

    if (!db.Users.Any())
    {
        db.Users.Add(new User
        {
            Email = "test@example.com",
            PasswordHash = "1234"
        });
        db.SaveChanges();
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
