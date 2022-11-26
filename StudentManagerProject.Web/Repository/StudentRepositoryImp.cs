using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagerProject.Web.Data;
using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public class StudentRepositoryImp : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepositoryImp(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> ChangeStudentActivationStatus(string studentId)
        {
            var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId);

            if (existingStudent == null)
                return null;

            existingStudent.Activated = !existingStudent.Activated;
            await _dbContext.SaveChangesAsync();

            return existingStudent;
        }

        public async Task<bool> DeleteStudentCompletely(string studentId)
        {
            var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId);

            if (existingStudent == null) return false;

            _dbContext.Students.Remove(existingStudent);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Student> GetAllStudentsByClassGroup(Guid groupId) => _dbContext.Students
            .Include(s => s.ClassGroup)
            .Where(s => s.ClassGroupId == groupId);

        public Student GetStudent(string studentId) => _dbContext.Students
            .Include(s => s.Records)
            .Include(s => s.ClassGroup)
            .FirstOrDefault(s => s.Id == studentId);

        public async Task<bool> removeStudentRecord(Guid recordId)
        {
            var record = await _dbContext.StudentSubjectRecords.FirstOrDefaultAsync(s => s.Id == recordId);
            if (record == null) return false;
            _dbContext.StudentSubjectRecords.Remove(record);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Student> UpdateStudentInfo(Student student)
        {
            var existingStudent = await _dbContext.FindAsync<Student>(student.Id);
            if (existingStudent == null) return null;

            // TODO - To continue update student info ..

            await _dbContext.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<StudentSubjectRecord> UpdateStudentRecord(StudentSubjectRecord record)
        {
            var existingStudent = await _dbContext.FindAsync<IdentityUser>(record.StudentId);
            if (existingStudent == null) return null;

            var existingSubject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Id == record.SubjectId);
            if (existingStudent == null) return null;

            await _dbContext.StudentSubjectRecords.AddRangeAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }
    }
}
