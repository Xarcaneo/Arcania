using Arcania.DataAccess.Repository.IRepository;
using Arcania.Filters;
using Arcania.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arcania.Areas.Player.Controllers
{
    [Area("Player")]
    [Authorize]
    public class GameController : Controller
    {
        private readonly IRepository<Race> _raceRepository;

        public GameController(IRepository<Race> db)
        {
            _raceRepository = db;
        }

        [EnsureCharacterCreated]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCharacter()
        {
            var races = _raceRepository.GetAll();

            return View(races);
        }
    }
}
