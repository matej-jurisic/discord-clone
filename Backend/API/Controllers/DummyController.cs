using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Modules.Dummy.Queries;
using Shared.CQRS;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.SendAsync(new GetDummyQuery("Dorina"));

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest();
        }
    }
}
