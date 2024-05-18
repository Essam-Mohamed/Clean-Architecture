using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    public class DinnerController : ApiController
    {
        [HttpGet]
        public IActionResult ListDinner()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
