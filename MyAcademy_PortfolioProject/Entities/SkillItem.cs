namespace MyAcademy_PortfolioProject.Entities
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }
        public string SkillItemTitle { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public int Level { get; set; }
    }
}
