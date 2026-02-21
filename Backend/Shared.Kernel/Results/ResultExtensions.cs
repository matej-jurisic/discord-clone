using Microsoft.AspNetCore.Mvc;

namespace Shared.Kernel.Results
{
    public static class ApiResultExtensions
    {
        public static IActionResult ToActionResult<T>(this Result<T> result) =>
            result.IsSuccess
                ? new OkObjectResult(result.Data)
                : new ObjectResult(new { errors = result.Messages }) { StatusCode = (int)result.StatusCode };

        public static IActionResult ToActionResult(this Result result) =>
            result.IsSuccess
                ? new OkResult()
                : new ObjectResult(new { errors = result.Messages }) { StatusCode = (int)result.StatusCode };
    }
}
