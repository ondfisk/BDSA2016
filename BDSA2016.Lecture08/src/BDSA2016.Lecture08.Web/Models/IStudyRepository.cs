using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture08.Web.Models
{
    public interface IStudyRepository
    {
        Task<int> CreateAsync(StudyDTO study);
        Task<StudyDTO> FindAsync(int studyId);
        IQueryable<StudyDTO> Read();
        Task<bool> UpdateAsync(StudyDTO study);
        Task<bool> DeleteAsync(int studyId);
    }
}
