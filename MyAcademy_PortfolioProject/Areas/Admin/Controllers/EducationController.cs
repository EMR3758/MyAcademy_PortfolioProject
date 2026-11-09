using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;
using System.Runtime.InteropServices;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult EducationList()
        {
            var values = context.Educations.OrderBy(e => e.DisplayOrder).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            context.Educations.Add(education);
            context.SaveChanges();
            TempData["Success"] = "Eğitim bilgisi başarıyla eklendi.";
            return RedirectToAction("EducationList");
        }
        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var value = context.Educations.Find(id);

            if (value == null)
                return NotFound();

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            var value = context.Educations.Find(education.EducationId);

            if (value == null)
                return NotFound();

            value.SchoolName = education.SchoolName;
            value.Department = education.Department;
            value.Degree = education.Degree;
            value.StartDate = education.StartDate;
            value.EndDate = education.EndDate;
            value.Description = education.Description;
            value.GPA = education.GPA;
            value.IsActive = education.IsActive;
            value.DisplayOrder = education.DisplayOrder;

            context.SaveChanges();

            TempData["Success"] = "Eğitim bilgisi güncellendi.";

            return RedirectToAction("EducationList");
        }

        [HttpPost]
        public IActionResult DeleteEducation(int id)
        {
            var value = context.Educations.Find(id);

            if (value == null)
                return NotFound();

            context.Educations.Remove(value);
            context.SaveChanges();

            TempData["Success"] = "Eğitim bilgisi silindi.";

            return RedirectToAction("EducationList");
        }

    }
}
