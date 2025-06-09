using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class UserSessionService
    {
        public event Action? OnChange;

        private User? _currentUser;
        public User? CurrentUser => _currentUser;

        public bool IsLoggedIn => _currentUser != null;

        public void SetUser(User user)
        {
            _currentUser = user;
            OnChange?.Invoke();
        }

        public void ClearUser()
        {
            _currentUser = null;
            OnChange?.Invoke();
        }
    }
}

