using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture05.Lib.Students
{
    public interface IStudentAsyncRepository : IDisposable
    {
        IQueryable<StudentListDto> Read();

        Task<int> CreateAsync(StudentCrudDto student);

        Task<bool> UpdateAsync(StudentCrudDto student);

        Task<bool> DeleteAsync(int studentId);
    }
}