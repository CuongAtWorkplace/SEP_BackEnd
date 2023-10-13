using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
