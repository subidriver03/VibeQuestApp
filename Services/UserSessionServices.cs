using VibeQuestApp.Models;

namespace VibeQuestApp.Services
{
    public class UserSessionService
    {
        private User? _currentUser;

        public event Action? OnChange;

        /// <summary>
        /// The currently logged-in user (read-only access).
        /// </summary>
        public User? CurrentUser => _currentUser;

        /// <summary>
        /// Indicates whether a user is currently logged in.
        /// </summary>
        public bool IsLoggedIn => _currentUser != null;

        /// <summary>
        /// Set the current user for the session.
        /// </summary>
        public void SetUser(User user)
        {
            _currentUser = user;
            OnChange?.Invoke();
        }

        /// <summary>
        /// Clears the current user from session.
        /// </summary>
        public void ClearUser()
        {
            _currentUser = null;
            OnChange?.Invoke();
        }
    }
}
