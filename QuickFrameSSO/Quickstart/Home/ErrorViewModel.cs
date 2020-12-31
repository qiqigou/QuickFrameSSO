using IdentityServer4.Models;

namespace QuickFrameSSO.Controllers
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
        }

        public ErrorViewModel(string error)
        {
            Error = new ErrorMessage { Error = error };
        }

        public ErrorMessage? Error { get; set; }
    }
}