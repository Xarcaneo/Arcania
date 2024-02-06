using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Arcania.DataAccess.Repository.IRepository; // Adjust if you have a specific IUserRepository
using Arcania.Models;
using Microsoft.Extensions.DependencyInjection; // For GetService

namespace Arcania.Filters
{
    public class CharacterExistenceFilterAttribute : ActionFilterAttribute
    {
        private readonly bool _shouldHaveCharacter;
        private readonly string _redirectController;
        private readonly string _redirectAction;

        public CharacterExistenceFilterAttribute(bool shouldHaveCharacter, string redirectController, string redirectAction)
        {
            _shouldHaveCharacter = shouldHaveCharacter;
            _redirectController = redirectController;
            _redirectAction = redirectAction;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userRepository = context.HttpContext.RequestServices.GetService<IRepository<ApplicationUser>>();
            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                var user = userRepository.Get(u => u.Id == userId, tracked: false); // Add 'tracked: false' if you do not need to track changes

                bool hasCharacter = user != null && user.HasCharacter;
                if (_shouldHaveCharacter != hasCharacter) // If the condition does not match the expected
                {
                    context.Result = new RedirectToActionResult(_redirectAction, _redirectController, null);
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
