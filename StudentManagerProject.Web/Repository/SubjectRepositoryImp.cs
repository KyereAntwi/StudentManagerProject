using Microsoft.EntityFrameworkCore;
using StudentManagerProject.Web.Data;
using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public class SubjectRepositoryImp : ISubjectRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SubjectRepositoryImp(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subject> AddANewSubject(Subject subject)
        {
            await _dbContext.Subjects.AddAsync(subject);
            return subject;
        }

        public async Task<bool> DeleteANewSubject(Subject subject)
        {
            var _subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Id == subject.Id);

            if (_subject == null)
                return false;

            _dbContext.Subjects.Remove(subject);
            return true;
        }

        public IEnumerable<Subject> FilterSubjects(string searchQuery) => _dbContext.Subjects
            .Where(s => s.Name.ToLower().Contains(searchQuery.ToLower()));

        public IEnumerable<Subject> GetAll() => _dbContext.Subjects;

        public Subject GetById(Guid id) 
        {
            var subject = _dbContext.Subjects
            .Include(s => s.Courses)
            .FirstOrDefault(s => s.Id == id);

            if (subject != null)
                return subject;
            return new Subject 
            {
                UniqueIdentifyer = "none"
            };
        }

        public Subject GetByIdentifyer(string identifyer)
        {
            var subject = _dbContext.Subjects
            .Include(s => s.Courses)
            .FirstOrDefault(s => s.UniqueIdentifyer == identifyer);

            if (subject != null)
                return subject;
            return new Subject
            {
                UniqueIdentifyer = "none"
            };
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            var _subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Id == subject.Id);

            if (_subject == null)
                return new Subject { UniqueIdentifyer = "none" };

            _dbContext.Subjects.Remove(subject);
            return subject;
        }
    }
}
