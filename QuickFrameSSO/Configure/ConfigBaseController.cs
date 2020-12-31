//using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.DependencyInjection;
using QuickFrameSSO.Attributes;

namespace QuickFrameSSO.Controllers
{
    [Authorize]
    [SecurityHeaders]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ConfigBaseController : Controller
    {
        //protected IConfigurationDbContext _configurationDbContext;

        //protected ConfigBaseController(IConfigurationDbContext configurationDbContext)
        //{
        //    _configurationDbContext = configurationDbContext;
        //}
    }
}
