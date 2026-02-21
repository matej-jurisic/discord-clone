using Microsoft.AspNetCore.Mvc;
using Modules.Servers.Application.Queries;
using Shared.Kernel.CQRS;

namespace Modules.Servers.Api.Controllers
{
    [ApiController]
    [Route("api/servers")]
    public class ServersController(
        IQueryHandler<GetDummyQuery, string> getDummyHandler
    ) : ControllerBase
    {
        [HttpGet("dummy")]
        public async Task<IActionResult> Dummy()
        {
            var result = await getDummyHandler.HandleAsync(new GetDummyQuery("hello from query"));

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
