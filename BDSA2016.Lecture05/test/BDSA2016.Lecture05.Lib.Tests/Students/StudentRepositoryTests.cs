using BDSA2016.Lecture05.Entities;
using BDSA2016.Lecture05.Lib.Students;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace BDSA2016.Lecture05.Lib.Tests.Students
{
    public class StudentRepositoryTests
    {
        [Fact]
        public void Create_returns_new_id()
        {
            var options = Helpers.CreateNewContextOptions();
            var context = new CourseBaseContext(options);
            var repository = new StudentRepository(context);

            using (repository)
            {
                var student = new StudentCrudDto();

                var id = repository.Create(student);

                Assert.Equal(1, id);
            }
        }

        [Fact]
        public void Create_calls_SaveChanges_on_context()
        {
            var mock = new Mock<ICourseBaseContext>();
            mock.Setup(m => m.Students.Add(It.IsAny<Student>()));

            var repository = new StudentRepository(mock.Object);
            using (repository)
            {
                var student = new StudentCrudDto();

                repository.Create(student);
            }

            mock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Read_active_returns_active()
        {
            var options = Helpers.CreateNewContextOptions();
            var context = new CourseBaseContext(options);

            context.Students.Add(new Student { Name = "Goofy" });
            context.Students.Add(new Student { Name = "Mickey" });
            context.Courses.Add(new Course { Name = "Course" });
            context.Dates.Add(new Date { CourseId = 1, Start = DateTime.Today.AddDays(-1), End = DateTime.Today.AddDays(1) });
            context.Enrolment.Add(new Enrolment { StudentId = 1, DateId = 1 });

            // Must call save changes to query
            context.SaveChanges();

            var repository = new StudentRepository(context);

            using (repository)
            {
                var students = repository.Read(Status.Active);
                var list = students.ToList();

                Assert.Equal("Goofy", list[0].Name);
                Assert.Equal(1, list[0].NumberOfEnrolments);
            }
        }
    }
}
