using Arcania.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arcania.Areas.Player.Controllers
{
    [Area("Player")]

    [Authorize]

    public class GameController : Controller
    {
        [EnsureCharacterCreated]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCharacter()
        {
            // The character creation page
            return View();
        }
    }
}
