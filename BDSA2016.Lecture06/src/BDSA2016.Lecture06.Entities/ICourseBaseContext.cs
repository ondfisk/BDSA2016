using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BDSA2016.Lecture05.Entities
{
    public interface ICourseBaseContext : IDisposable
    {
        DbSet<Category> Categories { get; }
        DbSet<Course> Courses { get; }
        DbSet<Date> Dates { get; }
        DbSet<Enrolment> Enrolment { get; }
        DbSet<Student> Students { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}