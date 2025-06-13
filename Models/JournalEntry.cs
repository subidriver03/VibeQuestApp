namespace VibeQuestApp.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Mood { get; set; }

    }
}
