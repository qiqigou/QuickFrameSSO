namespace QuickFrameSSO.Controllers
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; } = string.Empty;
    }
}