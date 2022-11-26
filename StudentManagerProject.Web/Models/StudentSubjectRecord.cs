using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagerProject.Web.Models
{
    public class StudentSubjectRecord
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } = default!;
        public string AcademicYear { get; set; } = string.Empty;
        public int Semester { get; set; }
        public decimal ClassScore { get; set; }
        public decimal ExamScore { get; set; }
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey("StudentId")]
        public Student Student { get; set; } = default!;
    }
}
