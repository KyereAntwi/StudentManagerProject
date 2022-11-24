using StudentManagerProject.Web.Models;
using StudentManagerProject.Web.ViewModels;

namespace StudentManagerProject.Web.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GelAllCourses();
        GetSingleCourseViewModel GetCourseById(Guid id);
        GetSingleCourseViewModel GetCourseByIdentifyer(string identifyer);

        Task<Course> CreateCourse(Course course);
        Task<CourseSubTopic> AddSubTopicAndParagraphsToCourse(CourseSubTopic courseSubTopic);
        Task<CourseParagraph> AddAParagraphToCourse(CourseParagraph courseParagraph);
        Task<Course> ModifyCourseDeatails(Course course);
        Task<Course> DeleteCourse(Guid id);
        Task<CourseParagraph> RemoveParagraphFromCourse(CourseParagraph courseParagraph);
        Task<Course> ChangeCoursePublishStatus(Course course);
    }
}
