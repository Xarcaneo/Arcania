using Microsoft.AspNetCore.Mvc;

namespace Arcania.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
