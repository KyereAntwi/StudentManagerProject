using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public interface IClassGroupRepository
    {
        IEnumerable<ClassGroup> GetAllGropup();
        Task<ClassGroup> CreateAClassGroup(ClassGroup classGroup);
        Task<ClassGroup> DeleteClassGroup(ClassGroup classGroup);
    }
}
