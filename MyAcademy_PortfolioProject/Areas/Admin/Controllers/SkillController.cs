using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult SkillList()
        {
            var values = context.Skills.Include(s => s.SkillItems).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult SkillCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SkillCreate(Skill skill)
        {
            context.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        [HttpGet]
        public IActionResult SkillUpdate(int id)
        {
            var values = context.Skills.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult SkillUpdate(Skill skill)
        {
            var values = context.Skills.Find(skill.SkillId);
            values.Title = skill.Title;
            values.Description = skill.Description;
            values.IconUrl = skill.IconUrl;
            context.Update(values);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        [HttpPost]
        public IActionResult SkillDelete(int id)
        {
            var value = context.Skills.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            context.Remove(value);
            context.SaveChanges();

            return RedirectToAction("SkillList");
        }

    }
}
