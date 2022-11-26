using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudentsByClassGroup(Guid groupId);
        Task<Student> ChangeStudentActivationStatus(string studentId);
        Task<bool> DeleteStudentCompletely(string studentId);
        Task<Student> UpdateStudentInfo(Student student);
        Student GetStudent(string studentId);

        Task<StudentSubjectRecord> UpdateStudentRecord(StudentSubjectRecord record);
        Task<bool> removeStudentRecord(Guid recordId);
    }
}
