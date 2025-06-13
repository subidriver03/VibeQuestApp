using System;

namespace VibeQuestApp.Models
{
    public class Quest
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = "General"; // e.g., Mind, Body, Productivity

        public int XpReward { get; set; } = 10;

        public bool IsCompleted { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string UserId { get; set; } = string.Empty;

        // Optional: Add priority or badge if you want visual sorting
        public string? Priority { get; set; }  // e.g., Low, Medium, High
    }
}
