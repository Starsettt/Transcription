using Transcription.Models;

namespace Transcription.Services
{
    public class AuthService
    {
        public User? CurrentUser { get; private set; }

        public event Action? OnChange;

        public void Login(User user)
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