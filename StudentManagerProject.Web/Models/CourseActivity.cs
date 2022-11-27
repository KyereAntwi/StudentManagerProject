using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagerProject.Web.Models
{
    public class CourseActivity : Activity
    {
        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; } = default!;
    }
}
