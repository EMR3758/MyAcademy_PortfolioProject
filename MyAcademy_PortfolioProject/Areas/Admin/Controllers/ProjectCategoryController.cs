using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectCategoryController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult ProjectCategoryList()
        {
            var values = context.ProjectCategories.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProjectCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProjectCategory(ProjectCategory category)
        {
            context.ProjectCategories.Add(category);
            context.SaveChanges();
            return RedirectToAction("ProjectCategoryList");
        }
        [HttpGet]
        public IActionResult UpdateProjectCategory(int id)
        {
            var value = context.ProjectCategories.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProjectCategory(ProjectCategory category)
        {
            var value = context.ProjectCategories.Find(category.ProjectCategoryId);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("ProjectCategoryList");
        }
        [HttpPost]
        public IActionResult DeleteProjectCategory(int id)
        {
            var value = context.ProjectCategories.Find(id);

            if (value == null)
                return NotFound();

            // Kategoriye bağlı proje var mı?
            var hasProjects = context.Projects.Any(x => x.ProjectCategoryId == id);

            if (hasProjects)
            {
                TempData["Error"] = "Bu kategoriye bağlı projeler bulunduğu için silinemez.";
                return RedirectToAction("ProjectCategoryList");
            }

            context.ProjectCategories.Remove(value);
            context.SaveChanges();

            TempData["Success"] = "Kategori başarıyla silindi.";

            return RedirectToAction("ProjectCategoryList");
        }
    }
}
