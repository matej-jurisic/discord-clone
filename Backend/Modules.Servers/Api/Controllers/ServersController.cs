using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modules.Servers.Infrastructure.Persistence;

namespace Modules.Servers.Api.Controllers
{
    [ApiController]
    [Route("api/servers")]
    public class ServersController(ServersDbContext context) : ControllerBase
    {
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok(await context.Servers.FirstOrDefaultAsync());
        }
    }
}
