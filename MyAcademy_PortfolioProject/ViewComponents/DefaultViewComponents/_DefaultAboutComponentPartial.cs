using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultAboutComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Abouts.FirstOrDefault();

            ViewBag.title = value.Title;
            ViewBag.subDescription = value.SubDescription;
            ViewBag.details = value.Details;
            ViewBag.imageUrl = value.ImageUrl;

            return View();
        }
    }
}