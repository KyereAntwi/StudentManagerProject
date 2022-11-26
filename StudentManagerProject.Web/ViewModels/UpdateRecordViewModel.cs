using System.ComponentModel.DataAnnotations;

namespace StudentManagerProject.Web.ViewModels
{
    public class UpdateRecordViewModel
    {
        [Required]
        [StringLength(9)]
        public string AcademicYear { get; set; } = string.Empty;
        public int Semester { get; set; }
        public decimal ClassScore { get; set; }
        public decimal ExamScore { get; set; }
        [Required]
        public Guid SubjectId { get; set; }
    }
}
