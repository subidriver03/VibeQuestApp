using VibeQuestApp.Data;
using VibeQuestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace VibeQuestApp.Services
{
    public class RewardStoreService
    {
        private readonly AppDbContext db;
        private readonly UserSessionService session;

        public RewardStoreService(AppDbContext db, UserSessionService session)
        {
            this.db = db;
            this.session = session;
        }

        /// <summary>
        /// Get the full HeroProfile for the current user.
        /// </summary>
        public async Task<HeroProfile?> GetHeroProfileAsync(string userId)
        {
            return await db.HeroProfiles.FirstOrDefaultAsync(h => h.UserId == userId);
        }

        /// <summary>
        /// Update the HeroProfile after modifying HeroCoins.
        /// </summary>
        public async Task UpdateHeroCoinsAsync(HeroProfile profile)
        {
            db.HeroProfiles.Update(profile);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// (Optional) Returns all available rewards from the database.
        /// </summary>
        public async Task<List<RewardItem>> GetAvailableRewardsAsync()
        {
            return await db.Rewards.ToListAsync();
        }

        /// <summary>
        /// (Optional) Returns current user’s HeroCoin balance.
        /// </summary>
        public async Task<int> GetHeroCoinBalanceAsync()
        {
            if (session.CurrentUser == null) return 0;

            var hero = await db.HeroProfiles.FirstOrDefaultAsync(h => h.UserId == session.CurrentUser.Id);
            return hero?.HeroCoins ?? 0;
        }

        /// <summary>
        /// (Optional) Spend coins to redeem a reward from the database-stored rewards.
        /// </summary>
        public async Task<bool> PurchaseRewardWithCoinsAsync(int rewardId)
        {
            if (session.CurrentUser == null) return false;

            var reward = await db.Rewards.FindAsync(rewardId);
            var hero = await db.HeroProfiles.FirstOrDefaultAsync(h => h.UserId == session.CurrentUser.Id);

            if (reward == null || hero == null || hero.HeroCoins < reward.XPPrice)
                return false;

            hero.HeroCoins -= reward.XPPrice;
            await db.SaveChangesAsync();
            return true;
        }
    }
}
