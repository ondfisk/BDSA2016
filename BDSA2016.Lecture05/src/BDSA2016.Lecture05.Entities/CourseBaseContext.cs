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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./coursebase.db");
        }
    }
}
