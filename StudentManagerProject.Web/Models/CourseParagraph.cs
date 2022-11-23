using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagerProject.Web.Models
{
    public class CourseParagraph
    {
        public Guid Id { get; set; }
        public string Details { get; set; } = string.Empty;
        public Guid CourseSubTopicId { get; set; }
        [ForeignKey("CourseSubTopicId")]
        public CourseSubTopic Chapter { get; set; } = default!;
    }
}
