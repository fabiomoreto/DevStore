using DevStore.SharedKernel.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AG.Products.API.Controllers
{
    public abstract class MainController : ControllerBase
    {
        protected IActionResult CustomResponse(Result requestResult)
        {
            if (!requestResult.IsSuccessful)
            {
                if (requestResult.Error == Error.NotFound)
                {
                    return NotFound();
                }

                var problemDetails = new ProblemDetails
                {
                    Title = "Um ou mais erros de validação ocorreram.",
                    Status = StatusCodes.Status400BadRequest,
                    Extensions =
                    {
                        ["errors"] = new []{ requestResult.Error }
                    }
                };

                return BadRequest(problemDetails);
            }

            return Ok();
        }
    }
}
