using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.OrderBy(x=>x.DisplayOrder).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Experiences.Add(experience);
                _context.SaveChanges();
                return RedirectToAction(nameof(ExperienceList));
            }
            return View(experience);
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                var existingExperience = _context.Experiences.Find(experience.ExperienceId);
                if (existingExperience == null)
                {
                    return NotFound();
                }
                existingExperience.Title = experience.Title;
                existingExperience.CompanyName = experience.CompanyName;
                existingExperience.Description = experience.Description;
                existingExperience.CategoryName = experience.CategoryName;
                existingExperience.StartDate = experience.StartDate;
                existingExperience.EndDate = experience.EndDate;
                existingExperience.IsCurrent = experience.IsCurrent;
                existingExperience.IsActive = experience.IsActive;
                existingExperience.DisplayOrder = experience.DisplayOrder;
                _context.SaveChanges();
                return RedirectToAction(nameof(ExperienceList));
            }
            return View(experience);
        }
        [HttpGet]
        public IActionResult GetExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }
        [HttpGet]
        public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            return View(value);
        }
        [HttpPost, ActionName("DeleteExperience")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExperienceConfirmed(int ExperienceId)
        {
            var value = _context.Experiences.Find(ExperienceId);
            if (value == null)
            {
                return NotFound();
            }
            _context.Experiences.Remove(value);
            _context.SaveChanges();
            return RedirectToAction(nameof(ExperienceList));
        }
    }
}
