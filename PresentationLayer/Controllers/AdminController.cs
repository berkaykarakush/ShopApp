using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
       public IActionResult Index()
        {
            return View();
        }
    }
}
