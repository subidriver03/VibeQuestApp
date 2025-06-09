using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Data;
using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class QuestService
    {
        private readonly AppDbContext _db;

        public QuestService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CompleteQuestAsync(int questId, int userId)
        {
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

        private int CalculateLevel(int totalXP)
        {
            return (int)Math.Floor(Math.Sqrt(totalXP / 100.0)) + 1;
        }
    }
}
