using System;
using System.ComponentModel.DataAnnotations;

namespace VibeQuestApp.Models
{
    public class HeroProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
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

        [Required]
        public string UserId { get; set; } = string.Empty;

        public User User { get; set; } = default!;

        public int JournalStreak { get; set; } = 0;
        public DateTime? LastJournalEntryDate { get; set; }

        public int XPRequiredForNextLevel => 50 * (Level + 1) * Level;
        public int XPIntoCurrentLevel => TotalXP - 50 * Level * (Level - 1);

        public double XPProgressPercentage
        {
            get
            {
                int required = XPRequiredForNextLevel;
                if (required == 0) return 0;
                return Math.Clamp((double)XPIntoCurrentLevel / required * 100, 0, 100);
            }
        }

        public int XPToNextLevel => XPRequiredForNextLevel - XPIntoCurrentLevel;

        public void RecalculateLevel()
        {
            int level = 1;
            int requiredXP = 0;

            while (TotalXP >= requiredXP)
            {
                level++;
                requiredXP = 50 * level * (level - 1);
            }

            Level = Math.Max(1, level - 1);
        }
    }
}
