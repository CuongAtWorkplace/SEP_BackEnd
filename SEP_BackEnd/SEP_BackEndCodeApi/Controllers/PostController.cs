using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    public class PostController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
