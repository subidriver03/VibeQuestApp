using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class UserSessionService
    {
        private User? _currentUser;

        public event Action? OnChange;

        public User? CurrentUser => _currentUser;

        public bool IsLoggedIn => _currentUser != null;

        public bool IsDeveloper => _currentUser?.IsDeveloper == true;

        public void SetUser(User user)
        {
            _currentUser = user;
            NotifyStateChanged();
        }

        public void ClearUser()
        {
            _currentUser = null;
            NotifyStateChanged();
        }

        public User? GetUser() => _currentUser;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
