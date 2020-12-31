using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using EF = IdentityServer4.EntityFramework.Entities;

namespace QuickFrameSSO.Controllers
{
    [AllowAnonymous]
    public class ClientController : ConfigBaseController
    {
        //public ClientController(IConfigurationDbContext configurationDbContext) : base(configurationDbContext)
        //{
        //}

        ///// <summary>
        ///// 查询客户端列表
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="size"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("{index:int}/{size:int}")]
        //public async Task<IActionResult> Index([FromRoute] int index = 1, [FromRoute] int size = 10)
        //{
        //    var clients =
        //        await _configurationDbContext
        //        .Clients
        //        .Include(x => x.AllowedGrantTypes)
        //        .Include(x => x.AllowedCorsOrigins)
        //        .Page(index, size)
        //        .ToListAsync();
        //    if (_configurationDbContext is DbContext dbContext)
        //    {
        //        dbContext.Set<ClientGrantType>();
        //    }
        //    return View(clients);
        //}

        ///// <summary>
        ///// 修改客户端
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPut]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update([FromForm] EF.Client input)
        //{
        //    _configurationDbContext.Clients.Update(input);
        //    return await Task.FromResult(Ok());
        //}
        ///// <summary>
        ///// 创建客户端
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromForm] EF.Client input)
        //{
        //    await _configurationDbContext.Clients.AddAsync(input);
        //    return Ok();
        //}
        ///// <summary>
        ///// 删除客户端
        ///// </summary>
        ///// <param name="clientId"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("{clientId}")]
        //public async Task<IActionResult> Delete([FromRoute] string clientId)
        //{
        //    _configurationDbContext.Clients.Remove(new EF.Client { ClientId = clientId });
        //    return await Task.FromResult(Ok());
        //}
    }
}
