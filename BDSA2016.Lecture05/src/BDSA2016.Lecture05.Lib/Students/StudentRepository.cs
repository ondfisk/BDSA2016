using System;
using System.Collections.Generic;
using BDSA2016.Lecture05.Entities;
using System.Linq;

namespace BDSA2016.Lecture05.Lib.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ICourseBaseContext _context;

        public StudentRepository(ICourseBaseContext context)
        {
            _context = context;
        }

        public int Create(StudentCrudDto student)
        {
            var entity = new Student { Name = student.Name };

            _context.Students.Add(entity);

            _context.SaveChanges();

            return student.Id = entity.Id;            
        }

        public bool Delete(int studentId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Enrol(int studentId, int dateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentListDto> Read()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentListDto> Read(Status status)
        {
            var students = from s in _context.Students
                           where s.Enrolments.Any(e => e.Date.Start < DateTime.Now && e.Date.End > DateTime.Now)
                           select new StudentListDto
                           {
                               Id = s.Id,
                               Name = s.Name,
                               NumberOfEnrolments = s.Enrolments.Count(),
                               LastEnrolmentDate = s.Enrolments.Max(e => e.EnrolmentDate)
                           };

            return students;
        }

        public bool Update(StudentCrudDto student)
        {
            throw new NotImplementedException();
        }
    }
}
