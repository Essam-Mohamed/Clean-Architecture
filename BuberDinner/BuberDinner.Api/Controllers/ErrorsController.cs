using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            #region Using throw excepton way from service to handel errors
            //var (statusCode, message) = exception switch
            //{
            //    IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            //    _ => (StatusCodes.Status500InternalServerError, "An Expected error occured")
            //};
            //return Problem(title: message, statusCode: statusCode);
            #endregion


            return Problem(title: exception?.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            //return Problem();
        }
    }
}
