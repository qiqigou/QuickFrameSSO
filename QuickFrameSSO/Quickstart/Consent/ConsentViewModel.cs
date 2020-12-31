using System;
using System.Collections.Generic;

namespace QuickFrameSSO.Controllers
{
    public class ConsentViewModel : ConsentInputModel
    {
        public string ClientName { get; set; } = string.Empty;
        public string ClientUrl { get; set; } = string.Empty;
        public string ClientLogoUrl { get; set; } = string.Empty;
        public bool AllowRememberConsent { get; set; }

        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; } = Array.Empty<ScopeViewModel>();
        public IEnumerable<ScopeViewModel> ApiScopes { get; set; } = Array.Empty<ScopeViewModel>();
    }
}
