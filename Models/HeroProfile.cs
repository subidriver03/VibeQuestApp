using System;
using System.ComponentModel.DataAnnotations;

namespace VibeQuestApp.Models
{
    public class HeroProfile
    {
        [Key]
        public int Id { get; set; }

        public string HeroName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string LifeFocusAreas { get; set; } = string.Empty;
        public string PrimaryGoals { get; set; } = string.Empty;
        public string LongTermVision { get; set; } = string.Empty;
        public string MotivationStyle { get; set; } = string.Empty;
        public string CommitmentLevel { get; set; } = string.Empty;
        public TimeSpan DailyResetTime { get; set; } = TimeSpan.FromHours(4);
        public int HeroCoins { get; set; } = 0;

        public int Level { get; set; } = 1;
        public int CurrentXP { get; set; } = 0;
        public int TotalXP { get; set; } = 0;

        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = default!;

        public int JournalStreak { get; set; } = 0;
        public DateTime? LastJournalEntryDate { get; set; }

        public int CalculateLevel()
        {
            int level = 1;
            int requiredXP = 0;

            while (TotalXP >= requiredXP)
            {
                level++;
                requiredXP = 50 * level * (level - 1);
            }

            return level - 1;
        }
    }
}
