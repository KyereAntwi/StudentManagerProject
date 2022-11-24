using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.ViewModels
{
    public class GetSingleCourseViewModel
    {
        public Course Course { get; set; } = default!;
        public IEnumerable<CourseSubTopic>? Chapters { get; set; }
    }
}
