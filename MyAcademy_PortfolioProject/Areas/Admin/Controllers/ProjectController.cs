using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult ProjectList()
        {
            var values = context.Projects.Include(x => x.ProjectCategory).OrderBy(x=>x.DisplayOrder).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProject()
        {
            ViewBag.Categories = new SelectList(
                context.ProjectCategories.ToList(),
                "ProjectCategoryId",
                "CategoryName"
            );

            return View(new Project
            {
                DisplayOrder = 1,
                IsActive = true
            });
        }
        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            project.CreatedDate = DateTime.Now;
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var value = context.Projects.Find(id);

            if (value == null)
                return NotFound();

            ViewBag.Categories = new SelectList(
                context.ProjectCategories.ToList(),
                "ProjectCategoryId",
                "CategoryName",
                value.ProjectCategoryId
            );

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            var value = context.Projects.Find(project.ProjectId);

            if (value == null)
                return NotFound();

            value.Title = project.Title;
            value.Description = project.Description;
            value.ImageUrl = project.ImageUrl;
            value.Technologies = project.Technologies;
            value.ProjectCategoryId = project.ProjectCategoryId;
            value.IsActive = project.IsActive;
            value.ProjectUrl = project.ProjectUrl;
            value.ProjectStatus = project.ProjectStatus;
            value.DisplayOrder = project.DisplayOrder;

            context.SaveChanges();

            return RedirectToAction("ProjectList");
        }

        [HttpPost]
        public IActionResult DeleteProject(int id)
        {
            var value = context.Projects.Find(id);

            if (value == null)
                return NotFound();

            context.Projects.Remove(value);
            context.SaveChanges();

            return RedirectToAction("ProjectList");
        }




    }
}
