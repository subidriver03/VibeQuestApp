using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Models;

namespace VibeQuestApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<HeroProfile> HeroProfiles => Set<HeroProfile>();
        public DbSet<Quest> Quests => Set<Quest>();
        public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add custom configurations here if needed
        }
    }
}
