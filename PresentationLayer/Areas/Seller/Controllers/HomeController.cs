using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize(Roles = "Seller")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
