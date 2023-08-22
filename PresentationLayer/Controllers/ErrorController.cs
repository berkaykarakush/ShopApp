using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace PresentationLayer.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("/error/")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                this.HttpContext.Response.StatusCode = statusCode.Value;
                Log.Fatal($"{statusCode} - Invalid Request", "Invalid Request");
            }

            return View();
        }
    }
}
