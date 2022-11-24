using Microsoft.EntityFrameworkCore;
using StudentManagerProject.Web.Data;
using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public class ClassGroupRepositoryImp : IClassGroupRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClassGroupRepositoryImp(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClassGroup> CreateAClassGroup(ClassGroup classGroup)
        {
            if (await _dbContext.ClassGroups.AnyAsync(g => g.GroupIdentity.ToLower() == classGroup.GroupIdentity.ToLower()))
                return new ClassGroup { id = Guid.Empty };

            await _dbContext.ClassGroups.AddAsync(classGroup);
            await _dbContext.SaveChangesAsync();

            return classGroup;
        }

        public async Task<ClassGroup> DeleteClassGroup(ClassGroup classGroup)
        {
            var group = await _dbContext.ClassGroups.FirstOrDefaultAsync(g => g.GroupIdentity.ToLower() == classGroup.GroupIdentity.ToLower());

            if (group == null)
                return new ClassGroup { id = Guid.Empty };

            _dbContext.ClassGroups .Remove (group);
            await _dbContext.SaveChangesAsync();

            return classGroup;
        }

        public IEnumerable<ClassGroup> GetAllGropup() => _dbContext.ClassGroups.Include(g => g.Students);
    }
}
