using Arcania.Models;
using Arcania.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Security.Claims;


namespace Arcania.Filters
{
    public class EnsureCharacterCreatedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var characterService = context.HttpContext.RequestServices.GetService<IUserCharacterService>();
            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId) && !characterService.HasCharacterAsync(userId).Result)
            {
                context.Result = new RedirectToActionResult("CreateCharacter", "Game", null);
            }
        }
    }
}
