using IdentityServer4.Models;

namespace QuickFrameSSO.Controllers
{
    public class ProcessConsentResult
    {
        public bool IsRedirect => RedirectUri != null;
        public string RedirectUri { get; set; } = string.Empty;
        public Client? Client { get; set; }

        public bool ShowView => ViewModel != null;
        public ConsentViewModel? ViewModel { get; set; }

        public bool HasValidationError => ValidationError != null;
        public string ValidationError { get; set; } = string.Empty;
    }
}
