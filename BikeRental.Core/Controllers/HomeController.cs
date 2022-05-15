using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Let's get started");
    }
}