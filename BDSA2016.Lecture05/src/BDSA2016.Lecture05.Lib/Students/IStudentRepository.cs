using System;
using System.Collections.Generic;

namespace BDSA2016.Lecture05.Lib.Students
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<StudentListDto> Read();

        IEnumerable<StudentListDto> Read(Status status);

        bool Enrol(int studentId, int dateId);

        int Create(StudentCrudDto student);

        bool Update(StudentCrudDto student);

        bool Delete(int studentId);
    }
}