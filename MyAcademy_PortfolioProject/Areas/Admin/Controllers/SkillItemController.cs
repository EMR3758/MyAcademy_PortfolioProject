using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillItemController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        [HttpGet]
        public IActionResult SkillItemCreate (int id)
        {
            ViewBag.skillId = id;
            return View();
        }
        [HttpPost]
        public IActionResult SkillItemCreate(SkillItem skillItem)
        {
            context.SkillItems.Add(skillItem);
            context.SaveChanges();

            return RedirectToAction("SkillList", "Skill");
        }
        [HttpGet]
        public IActionResult SkillItemUpdate(int id)
        {
            var value = context.SkillItems.Find(id);

            if (value == null)
                return NotFound();

            return View(value);
        }
        [HttpPost]
        public IActionResult SkillItemUpdate(SkillItem skillItem)
        {
            var value = context.SkillItems.Find(skillItem.SkillItemId);

            if (value == null)
                return NotFound();

            value.SkillItemTitle = skillItem.SkillItemTitle;
            value.Level = skillItem.Level;

            context.SaveChanges();

            return RedirectToAction("SkillList", "Skill");
        }

        public IActionResult SkillItemDelete(int id)
        {
            var value = context.SkillItems.Find(id);

            if (value == null)
                return NotFound();

            context.SkillItems.Remove(value);
            context.SaveChanges();

            return RedirectToAction("SkillList", "Skill");
        }
    }
}
