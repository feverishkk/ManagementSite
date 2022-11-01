using Microsoft.AspNetCore.Mvc;

namespace MyGameSite.Controllers
{
    public class CommonDbController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}
