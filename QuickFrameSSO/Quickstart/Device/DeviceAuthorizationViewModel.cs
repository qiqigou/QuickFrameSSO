namespace QuickFrameSSO.Controllers
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; } = string.Empty;
        public bool ConfirmUserCode { get; set; }
    }
}