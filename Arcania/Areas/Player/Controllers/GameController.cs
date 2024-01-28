using Microsoft.AspNetCore.Mvc;

namespace Arcania.Areas.Player.Controllers
{
    [Area("Player")]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
