using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagerProject.Web.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string UniqueIdentifyer { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public Guid SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } = default!;
        public string? Summary { get; set; }
        public bool Published { get; set; }
        public DateTime DatePublished { get; set; }

        public List<Tutor>? Tutors { get; set; }
        public List<CourseSubTopic>? Chapters { get; set; }
    }
}
