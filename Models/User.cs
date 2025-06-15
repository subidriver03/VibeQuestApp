using Microsoft.AspNetCore.Identity;

namespace VibeQuestApp.Models
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public bool IsDeveloper { get; set; } = false;

    }
}
