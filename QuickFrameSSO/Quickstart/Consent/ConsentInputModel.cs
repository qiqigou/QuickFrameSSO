using System.Collections.Generic;

namespace QuickFrameSSO.Controllers
{
    public class ConsentInputModel
    {
        public string Button { get; set; } = string.Empty;
        public IEnumerable<string>? ScopesConsented { get; set; }
        public bool RememberConsent { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}