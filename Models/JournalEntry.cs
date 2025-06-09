namespace VibeQuestApp.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; } // foreign key
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
