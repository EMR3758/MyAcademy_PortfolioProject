
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroController : Controller
    {
        PortfolioContext context = new PortfolioContext();

        public IActionResult Hero()
        {
            var value = context.HeroSections.FirstOrDefault();
            if (value == null)
            {
                return RedirectToAction("CreateHero");
            }
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateHero()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHero(HeroSection heroSection)
        {
            context.HeroSections.Add(heroSection);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateHero()
        {
            var value = context.HeroSections.FirstOrDefault();

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateHero(HeroSection heroSection)
        {
            var value = context.HeroSections.FirstOrDefault();

            if (value == null)
            {
                context.HeroSections.Add(heroSection);
            }
            else
            {
                value.Greeting = heroSection.Greeting;
                value.Title = heroSection.Title;
                value.Description = heroSection.Description;
                value.MainImageUrl = heroSection.MainImageUrl;
            }

            context.SaveChanges();

            return RedirectToAction("Hero");
        }
    }
}
