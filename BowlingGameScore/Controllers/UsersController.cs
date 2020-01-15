using System;

using BowlingGameScore.Interface;
using BowlingGameScore.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGameScore.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserLogic _delivery;

        public UsersController(IUserLogic delivery)
        {
            _delivery = delivery;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserViewModel model, int firstDelivery, int secondDelivery)
        {
            _delivery.SetGame(model, firstDelivery, secondDelivery);

            return View(model);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}