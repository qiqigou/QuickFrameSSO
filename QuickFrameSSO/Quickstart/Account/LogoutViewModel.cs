namespace QuickFrameSSO.Controllers
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
