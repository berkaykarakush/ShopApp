using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CampaignController : Controller
    {
        public IActionResult ListCampaign()
        {
            return View();
        }
    }
}
