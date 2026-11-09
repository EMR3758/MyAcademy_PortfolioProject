using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroTitleController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult HeroTitleList()
        {
            var values = context.HeroTitles.OrderBy(x => x.Order).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateHeroTitle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateHeroTitle(HeroTitle heroTitle)
        {
            context.HeroTitles.Add(heroTitle);
            context.SaveChanges();
            return RedirectToAction("HeroTitleList");
        }

        [HttpGet]
        public IActionResult UpdateHeroTitle(int id)
        {
            var value = context.HeroTitles.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateHeroTitle(HeroTitle heroTitle)
        {
            var value = context.HeroTitles.Find(heroTitle.HeroTitleId);

            if (value != null)
            {
                value.Title = heroTitle.Title;
                value.Order = heroTitle.Order;
                value.IsActive = heroTitle.IsActive;

                context.SaveChanges();
            }

            return RedirectToAction("HeroTitleList");
        }

        public IActionResult DeleteHeroTitle(int id)
        {
            var value = context.HeroTitles.Find(id);

            if (value != null)
            {
                context.HeroTitles.Remove(value);
                context.SaveChanges();
            }

            return RedirectToAction("HeroTitleList");
        }

    }
}
