using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagerProject.Web.Models
{
    public class CourseSubTopic
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Introduction { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; } = default!;

        public List<CourseParagraph>? Paragraphs { get; set; }
    }
}
