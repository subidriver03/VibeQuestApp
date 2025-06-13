using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Data;
using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class QuestService(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<bool> CompleteQuestAsync(int questId, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return false;

            var quest = await _db.Quests.FirstOrDefaultAsync(q => q.Id == questId && q.UserId == userId);
            var profile = await _db.HeroProfiles.FirstOrDefaultAsync(p => p.UserId == userId);

            if (quest == null || profile == null || quest.IsCompleted)
                return false;

            quest.IsCompleted = true;

            profile.TotalXP += quest.XpReward;
            profile.CurrentXP += quest.XpReward;
            profile.Level = CalculateLevel(profile.TotalXP);

            await _db.SaveChangesAsync();
            return true;
        }

        private static int CalculateLevel(int totalXP)
        {
            return (int)Math.Floor(Math.Sqrt(totalXP / 100.0)) + 1;
        }
    }
}
