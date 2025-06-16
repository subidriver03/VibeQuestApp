using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Data;
using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class RewardStoreService(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<HeroProfile?> GetHeroProfileAsync(string userId)
        {
            return await _db.HeroProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<bool> UpdateHeroCoinsAsync(HeroProfile profile)
        {
            var existingProfile = await _db.HeroProfiles.FirstOrDefaultAsync(p => p.Id == profile.Id);
            if (existingProfile == null) return false;

            existingProfile.HeroCoins = profile.HeroCoins;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
