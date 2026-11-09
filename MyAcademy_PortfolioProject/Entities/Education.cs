namespace MyAcademy_PortfolioProject.Entities
{
    public class Education
    {
        public int EducationId { get; set; }
        public string SchoolName { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public double? GPA { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }

    }
}
