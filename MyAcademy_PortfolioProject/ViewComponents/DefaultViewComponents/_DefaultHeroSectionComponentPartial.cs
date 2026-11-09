using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeroSectionComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultHeroSectionComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.HeroSections.Take(1).FirstOrDefault();
            ViewBag.greetings = value.Greeting;
            ViewBag.title = value.Title;
            ViewBag.description = value.Description;
            ViewBag.mainImageUrl = value.MainImageUrl;

            var socialMediaLinks = _context.SocialMedias
                .Where(sm => sm.IsActive == "Aktif")
                .OrderBy(sm => sm.Order)
                .ToList();
            ViewBag.socialMedias = socialMediaLinks;

            var heroTitles = _context.HeroTitles
                .Where(ht => ht.IsActive == "Aktif")
                .OrderBy(ht => ht.Order)
                .ToList();
            ViewBag.heroTitles = heroTitles;
            return View();
        }
    
    }
}
