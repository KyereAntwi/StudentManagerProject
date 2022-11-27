using Microsoft.EntityFrameworkCore;
using StudentManagerProject.Web.Data;
using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Repository
{
    public class CourseActivitiesRepositoryImp : ICourseActivitiesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseActivitiesRepositoryImp(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<CourseActivity> AddCourseActivity(CourseActivity activity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseActivity(CourseActivity activity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseActivity> GetCourseActivitesByTutor(string tutorId) 
        {
            var tutor = _dbContext.Tutors.First(t => t.Id == tutorId);
            var coures = _dbContext.Courses.Include(c => c.Tutors).Where(c => c.Tutors.Contains(tutor));

            if (coures.Count() == 0)
                return null;

            List<CourseActivity> existingActivities = new List<CourseActivity>();

            foreach ( var coure in coures) 
            {
                var activities = _dbContext.CourseActivities.Where(a => a.CourseId == coure.Id);
                if (activities.Count() > 0) 
                {
                    existingActivities.AddRange(activities.ToList());
                }
            }

            IEnumerable<CourseActivity> courseActivities = existingActivities;
            return courseActivities;
        }
    }
}
