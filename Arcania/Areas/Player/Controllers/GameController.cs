using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arcania.Areas.Player.Controllers
{
    [Area("Player")]

    [Authorize]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
