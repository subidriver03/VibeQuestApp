namespace VibeQuestApp.Models
{
    public class HeroProfile
    {
        public int Id { get; set; }
        public string HeroName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string LifeFocusAreas { get; set; } = string.Empty;
        public string PrimaryGoals { get; set; } = string.Empty;
        public string LongTermVision { get; set; } = string.Empty;
        public string MotivationStyle { get; set; } = string.Empty;
        public string CommitmentLevel { get; set; } = string.Empty;
        public TimeSpan DailyResetTime { get; set; } = TimeSpan.FromHours(4);

        public int Level { get; set; } = 1;
        public int CurrentXP { get; set; } = 0;

        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int TotalXP { get; set; } // This tracks the user's current XP

    }

}
