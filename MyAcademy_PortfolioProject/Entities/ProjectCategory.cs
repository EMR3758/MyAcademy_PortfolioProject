namespace MyAcademy_PortfolioProject.Entities
{
    public class ProjectCategory
    {
        public int ProjectCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Project> Projects { get; set; }
    }
}
