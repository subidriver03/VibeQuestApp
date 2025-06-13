using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class OnboardingStateService
    {
        public HeroProfile HeroProfile { get; set; } = new();
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        public void Reset()
        {
            HeroProfile = new();
            Email = null;
            Password = null;
            ConfirmPassword = null;
        }
    }
}
