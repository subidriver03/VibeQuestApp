using System.ComponentModel.DataAnnotations;

namespace VibeQuestApp.Models
{
    public class RewardItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public int XPPrice { get; set; }

        public string ImageUrl { get; set; } = "/images/rewards/default.png";
    }
}
