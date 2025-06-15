using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Data;
using VibeQuestApp.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace VibeQuestApp.Services
{
    public class DevToolService(AppDbContext db)
    {
        private readonly AppDbContext _db = db;
        public AppDbContext Db => _db;

        public async Task<HeroProfile?> GetHeroProfileAsync(string userId)
        {
            return await _db.HeroProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<List<HeroProfile>> GetAllHeroProfilesAsync()
        {
            return await _db.HeroProfiles.ToListAsync();
        }

        public async Task ResetXPAsync(string userId)
        {
            var profile = await GetHeroProfileAsync(userId);
            if (profile != null)
            {
                profile.CurrentXP = 0;
                profile.TotalXP = 0;
                profile.Level = 1;
                await _db.SaveChangesAsync();
            }
        }

        public async Task ModifyXPAsync(string userId, int amount)
        {
            var profile = await GetHeroProfileAsync(userId);
            if (profile != null)
            {
                profile.CurrentXP += amount;
                profile.TotalXP += amount;

                if (profile.CurrentXP < 0) profile.CurrentXP = 0;
                if (profile.TotalXP < 0) profile.TotalXP = 0;

                profile.RecalculateLevel();

                await _db.SaveChangesAsync();
            }
        }


        public async Task ModifyCoinsAsync(string userId, int amount)
        {
            var profile = await GetHeroProfileAsync(userId);
            if (profile != null)
            {
                profile.HeroCoins += amount;
                if (profile.HeroCoins < 0) profile.HeroCoins = 0;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateAvatarAsync(string userId, IBrowserFile file)
        {
            var profile = await GetHeroProfileAsync(userId);
            if (profile == null || file == null) return false;

            var extension = Path.GetExtension(file.Name);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var uploadPath = Path.Combine("wwwroot/uploads", fileName);

            Directory.CreateDirectory("wwwroot/uploads");

            await using var stream = File.Create(uploadPath);
            await file.OpenReadStream().CopyToAsync(stream);

            profile.AvatarUrl = $"/uploads/{fileName}";
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task WipeUserQuestsAsync(string userId)
        {
            var quests = _db.Quests.Where(q => q.UserId == userId);
            _db.Quests.RemoveRange(quests);
            await _db.SaveChangesAsync();
        }

        public async Task WipeUserDataAsync(string userId)
        {
            await WipeUserQuestsAsync(userId);

            var profile = await GetHeroProfileAsync(userId);
            if (profile != null)
            {
                _db.HeroProfiles.Remove(profile);
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                _db.Users.Remove(user);
            }

            await _db.SaveChangesAsync();
        }

        private static int CalculateLevel(int totalXP)
        {
            // Example: Level up every 1000 XP
            return Math.Max(1, totalXP / 1000 + 1);
        }
    }
}
