using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Context
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
    "Server=EMIRHAN\\SQLEXPRESS;Database=PortfolioDayDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<HeroSection> HeroSections { get; set; }
        public DbSet<HeroTitle> HeroTitles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillItem> SkillItems { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; internal set; }
    }
}
