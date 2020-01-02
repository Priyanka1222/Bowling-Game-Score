using System;

using BowlingGameScore.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGameScore.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly Deliverie _deliverie;

        public DeliveriesController(Deliverie deliverie)
        {
            _deliverie = deliverie;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Deliverie model, int firstDeliverie, int secondDeliverie)
        {
            for (int i = 0; i <= 9; i++)
            {
                _deliverie.AddDeliverie(model.Deliveries[i].FirstDeliverie, model.Deliveries[i].SecondDeliverie);
            }

            _deliverie.CheckForStrike();
            _deliverie.CheckForSpare();


            if (!firstDeliverie.Equals(null) || !secondDeliverie.Equals(null))
            {
                _deliverie.FinalStrike(firstDeliverie, secondDeliverie);
                _deliverie.FinalSpare(firstDeliverie);
            }

            ViewBag.Message = _deliverie.FinalScore();

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