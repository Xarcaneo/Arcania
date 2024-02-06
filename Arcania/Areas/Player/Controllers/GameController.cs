using Arcania.DataAccess.Repository.IRepository;
using Arcania.Filters;
using Arcania.Models;
using Arcania.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Arcania.Areas.Player.Controllers
{
    [Area("Player")]
    [Authorize]
    public class GameController : Controller
    {
        private readonly IRepository<Race> _raceRepository;
        private readonly IApplicationUserRepository _applicationUser;
        private readonly UserManager<IdentityUser> _userManager;

        public GameController(IRepository<Race> db, UserManager<IdentityUser> userManager, IApplicationUserRepository applicationUser)
        {
            _raceRepository = db;
            _userManager = userManager;
            _applicationUser = applicationUser;
        }

        [CharacterExistenceFilter(shouldHaveCharacter: true, redirectController: "Game", redirectAction: "CreateCharacter")]
        public IActionResult Index()
        {
            return View();
        }

        [CharacterExistenceFilter(shouldHaveCharacter: false, redirectController: "Game", redirectAction: "Index")]
        public IActionResult CreateCharacter()
        {
            // Create a new Character entity from the selected values
            CharacterCreationVM characterCreationVM = new()
            {
                AvailableRaces = _raceRepository.GetAll(),
                Character = new CharacterVM()
            };

            return View(characterCreationVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter(CharacterVM model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already has a character
                var userId = _userManager.GetUserId(User);

                var user = _applicationUser.Get(u => u.Id == userId);

                if (user.HasCharacter)
                {
                    ModelState.AddModelError(string.Empty, "You already have a character.");
                    return RedirectToAction("Index");
                }
                else
                {
                    await _applicationUser.CreateCharacterForUserAsync(userId, model.SelectedRace, model.SelectedGender);
                    return RedirectToAction("Index");
                }
            }

            // If there's a validation error, or you need to return to the form
            // Ensure to repopulate the AvailableRaces or any necessary data before returning
            return View(model);
        }
    }
}
