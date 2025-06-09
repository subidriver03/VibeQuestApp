using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Models;
namespace VibeQuestApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HeroProfile> HeroProfiles { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
    }

}
