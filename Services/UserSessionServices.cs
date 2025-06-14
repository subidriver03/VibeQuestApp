using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class UserSessionService
    {
        private User? _currentUser;

        public event Action? OnChange;

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

        public virtual User? GetUser()
        {
            return _currentUser;
        }
    }
}
