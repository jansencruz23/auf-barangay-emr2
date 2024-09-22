using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Controllers;

[Route("api/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public ActionResult<ProblemDetails> Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            NotImplementedException notImplementedException => (StatusCodes.Status501NotImplemented, notImplementedException.Message),
            _ => (StatusCodes.Status500InternalServerError, "An expected error occurred.")
        };

        return Problem(
            statusCode: statusCode,
            title: message
        );
    }
}
