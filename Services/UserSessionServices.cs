using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class UserSessionService
    {
        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action? OnChange;

        public void SetUser(User? user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
