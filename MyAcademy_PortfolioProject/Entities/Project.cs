namespace MyAcademy_PortfolioProject.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Technologies { get; set; }
        public int ProjectCategoryId { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProjectUrl { get; set; }
        public string ProjectStatus { get; set; }
        public int DisplayOrder { get; set; }
    }
}
