using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutId);
            value.Title = about.Title;
            value.SubDescription = about.SubDescription;
            value.Details = about.Details;
            value.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpPost]
        public IActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            context.Abouts.Remove(value);
            context.SaveChanges();

            return RedirectToAction("AboutList");
        }
        

    }

}
