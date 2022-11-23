using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(Guid id);
        Subject GetByIdentifyer(string identifyer);
        Task<Subject> AddANewSubject(Subject subject);
        Task<bool> DeleteANewSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        IEnumerable<Subject> FilterSubjects(string searchQuery);
    }
}
