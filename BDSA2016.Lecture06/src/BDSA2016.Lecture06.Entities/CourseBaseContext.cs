using Microsoft.EntityFrameworkCore;

namespace BDSA2016.Lecture05.Entities
{
    public class CourseBaseContext : DbContext, ICourseBaseContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Enrolment> Enrolment { get; set; }
        public DbSet<Student> Students { get; set; }

        public CourseBaseContext()
        {
        }

        public CourseBaseContext(DbContextOptions<CourseBaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define n:n relationship between Course and Category
            modelBuilder.Entity<CourseCategory>()
                .HasKey(t => new { t.CourseId, t.CategoryId });

            modelBuilder.Entity<CourseCategory>()
                .HasOne(c => c.Course)
                .WithMany(c => c.CourseCategories)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<CourseCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.CourseCategories)
                .HasForeignKey(pt => pt.CategoryId);

            // Set make Comment on Date max length 100
            modelBuilder.Entity<Date>()
                .Property(d => d.Comment).HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // cd src\BDSA2016.Lecture05.Entities
            // dotnet ef --startup-project ../BDSA2016.Lecture05.App/ migrations add Initial   
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=./coursebase.db");
            }
        }
    }
}
