using BDSA2016.Lecture05.Entities;

namespace BDSA2016.Lecture05.Lib.Students
{
    public class StudentRepository //: IStudentRepository
    {
        private readonly ICourseBaseContext _context;

        public StudentRepository(ICourseBaseContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
