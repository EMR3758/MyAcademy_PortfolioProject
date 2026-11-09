namespace MyAcademy_PortfolioProject.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; }
        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }

    }
}
