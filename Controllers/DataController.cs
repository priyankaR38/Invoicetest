
using Microsoft.AspNetCore.Mvc;

namespace display_an_invoice3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(new { message = "Data fetched" });
        }
    }
}
