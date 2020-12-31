namespace QuickFrameSSO.Controllers
{
    public class ScopeViewModel
    {
        public string Value { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Emphasize { get; set; }
        public bool Required { get; set; }
        public bool Checked { get; set; }
    }
}
