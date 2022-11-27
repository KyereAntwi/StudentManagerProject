using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public interface ICourseActivitiesRepository
    {
        IEnumerable<CourseActivity> GetCourseActivitesByTutor(string tutorId);
        Task<CourseActivity> AddCourseActivity(CourseActivity activity);
        Task<bool> DeleteCourseActivity(CourseActivity activity);
    }
}
