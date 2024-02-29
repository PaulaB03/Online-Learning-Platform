using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet("1")]
        public string Get()
        {
            return "You pressed me";
        }

        [HttpGet("2")]
        [Authorize(Roles = "Admin")]
        public string GetAdmin()
        {
            return "You pressed me Admin";
        }
    }
}
