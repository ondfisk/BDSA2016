using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture08.Web.Models
{
    public class StaticStudyRepository : IStudyRepository
    {
        private static readonly HashSet<Study> _studies;

        static StaticStudyRepository()
        {
            _studies = new HashSet<Study> {
            new Study { Id = 1, Name = "Study no. 1", CreateDate = DateTime.Today.AddDays(-5) },
            new Study { Id = 2, Name = "Study no. 2", CreateDate = DateTime.Today.AddDays(-4) },
            new Study { Id = 3, Name = "Study no. 3", CreateDate = DateTime.Today.AddDays(-3) },
            new Study { Id = 4, Name = "Study no. 4", CreateDate = DateTime.Today.AddDays(-2) },
            new Study { Id = 5, Name = "Study no. 5", CreateDate = DateTime.Today.AddDays(-1) },
        };
        }

        public async Task<int> CreateAsync(StudyDTO study)
        {
            await Task.FromResult(0); // remove async warning hack

            var id = _studies.Select(s => s.Id).DefaultIfEmpty().Max();

            var entity = new Study { Id = ++id, Name = study.Name, CreateDate = DateTime.Today };

            _studies.Add(entity);

            return id;
        }

        public async Task<StudyDTO> FindAsync(int studyId)
        {
            await Task.FromResult(0); // remove async warning hack

            var study = _studies.FirstOrDefault(s => s.Id == studyId);

            if (study == null)
            {
                return null;
            }

            return new StudyDTO { Id = study.Id, Name = study.Name };
        }

        public IQueryable<StudyDTO> Read()
        {
            return _studies.Select(s => new StudyDTO { Id = s.Id, Name = s.Name }).AsQueryable();
        }

        public async Task<bool> UpdateAsync(StudyDTO study)
        {
            await Task.FromResult(0); // remove async warning hack

            var entity = _studies.FirstOrDefault(s => s.Id == study.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = study.Name;

            return true;
        }

        public async Task<bool> DeleteAsync(int studyId)
        {
            await Task.FromResult(0); // remove async warning hack

            var entity = _studies.FirstOrDefault(s => s.Id == s.Id);

            if (entity == null)
            {
                return false;
            }

            _studies.Remove(entity);

            return true;
        }
    }
}