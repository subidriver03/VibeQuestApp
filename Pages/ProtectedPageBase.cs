using Microsoft.AspNetCore.Components;
using VibeQuestApp.Services;

namespace VibeQuestApp.Pages
{
    public class ProtectedPageBase : ComponentBase
    {
        [Inject]
        public required UserSessionService Session { get; set; }

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            if (Session.CurrentUser == null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
