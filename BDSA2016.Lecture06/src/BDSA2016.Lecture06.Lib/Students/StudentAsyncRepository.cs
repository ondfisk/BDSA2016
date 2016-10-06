using BDSA2016.Lecture05.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BDSA2016.Lecture05.Lib.Students
{
    public class StudentAsyncRepository : IStudentAsyncRepository
    {
        private readonly ICourseBaseContext _context;

        public StudentAsyncRepository(ICourseBaseContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(StudentCrudDto student)
        {
            var entity = new Student { Name = student.Name };

            _context.Students.Add(entity);

            await _context.SaveChangesAsync();

            return student.Id = entity.Id;
        }

        public IQueryable<StudentListDto> Read()
        {
            var students = from s in _context.Students
                           select new StudentListDto
                           {
                               Id = s.Id,
                               Name = s.Name,
                               NumberOfEnrolments = s.Enrolments.Count(),
                               LastEnrolmentDate = s.Enrolments.Max(e => e.EnrolmentDate)
                           };

            return students;
        }

        public async Task<bool> UpdateAsync(StudentCrudDto student)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = student.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
