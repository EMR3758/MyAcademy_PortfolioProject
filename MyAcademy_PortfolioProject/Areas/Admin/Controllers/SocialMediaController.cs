
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        PortfolioContext context = new PortfolioContext();

        public IActionResult SocialMediaList()
        {
            var values = context.SocialMedias
                .OrderBy(x => x.Order)
                .ToList();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedias.Add(socialMedia);
            context.SaveChanges();

            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = context.SocialMedias.Find(socialMedia.SocialMediaId);

            if (value != null)
            {
                value.Platform = socialMedia.Platform;
                value.Url = socialMedia.Url;
                value.Icon = socialMedia.Icon;
                value.Order = socialMedia.Order;
                value.IsActive = socialMedia.IsActive;

                context.SaveChanges();
            }

            return RedirectToAction("SocialMediaList");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);

            if (value != null)
            {
                context.SocialMedias.Remove(value);
                context.SaveChanges();
            }

            return RedirectToAction("SocialMediaList");
        }
    }
}
