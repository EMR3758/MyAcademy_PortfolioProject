using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult Index()
        {
            ViewBag.TotalProjects = context.Projects.Count();
            ViewBag.ActiveProjects = context.Projects.Count(x => x.IsActive);

            ViewBag.TotalExperiences = context.Experiences.Count();
            ViewBag.TotalSkills = context.Skills.Count();

            ViewBag.TotalMessages = context.Messages.Count();
            ViewBag.UnreadMessages = context.Messages.Count(x => !x.IsRead);

            ViewBag.RecentMessages = context.Messages.OrderByDescending(x => x.SendDate).Take(5).ToList();
            ViewBag.RecentProjects = context.Projects.OrderByDescending(x => x.CreatedDate).Take(5).ToList();

            return View("Dashboard");
        }
    }
}
