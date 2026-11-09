using Microsoft.AspNetCore.Mvc;

namespace MyAcademy_PortfolioProject.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
