using Microsoft.EntityFrameworkCore;
using StudentManagerProject.Web.Data;
using StudentManagerProject.Web.Models;
using StudentManagerProject.Web.ViewModels;

namespace StudentManagerProject.Web.Repository
{
    public class CourseRepositoryImp : ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseRepositoryImp(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CourseParagraph> AddAParagraphToCourse(CourseParagraph courseParagraph)
        {
            var courseSubTopic = await _dbContext.CourseChapters
                .FirstOrDefaultAsync(c => c.Id == courseParagraph.CourseSubTopicId);

            if(courseSubTopic == null)
                return new CourseParagraph() 
                {
                    Id = Guid.Empty
                };

            await _dbContext.CourseParagraphs.AddAsync(courseParagraph);
            await _dbContext.SaveChangesAsync();

            return courseParagraph;
        }

        public async Task<CourseSubTopic> AddSubTopicAndParagraphsToCourse(CourseSubTopic courseSubTopic)
        {
            if(await _dbContext.CourseChapters.AnyAsync(c => c.Introduction.ToLower().Contains(courseSubTopic.Introduction.ToLower())))
                return new CourseSubTopic() { Id = Guid.Empty };

            if (await _dbContext.Courses.AnyAsync(c => c.Id == courseSubTopic.CourseId))
            {
                await _dbContext.CourseChapters.AddAsync(courseSubTopic);
                await _dbContext.SaveChangesAsync();
                return courseSubTopic;
            }
            else 
            {
                return new CourseSubTopic() { Id = Guid.Empty };
            }
        }

        public async Task<Course> ChangeCoursePublishStatus(Course course)
        {
            var _course = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);

            if (course == null)
                return new Course { Id = Guid.Empty };

            _course.Published = !_course.Published;
            await _dbContext.SaveChangesAsync();
            return _course;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            if(await _dbContext.Courses.AnyAsync(c => c.UniqueIdentifyer.ToLower() == course.UniqueIdentifyer.ToLower()))
                return new Course { Id = Guid.Empty };

            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteCourse(Guid id)
        {
            var course = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if(course == null)
                return new Course { Id = Guid.Empty };

            //TODO - Remove all depecies of course before final deletion

            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
            return course;
        }

        public IEnumerable<Course> GelAllCourses() => _dbContext.Courses
            .Include(c => c.Tutors)
            .Include(c => c.Chapters);

        public GetSingleCourseViewModel GetCourseById(Guid id) 
        {
            var course = _dbContext.Courses
                .Include(c => c.Tutors)
                .Include(c => c.Chapters)
                .FirstOrDefault(c => c.Id == id);

            GetSingleCourseViewModel vm = new GetSingleCourseViewModel();
            vm.Course = course;

            if (course.Chapters.Count > 0) 
            {
                foreach (var chapter in course.Chapters) 
                {
                    vm.Chapters.Append(_dbContext.CourseChapters.Include(c => c.Paragraphs).FirstOrDefault(c => c.Id == chapter.Id));
                }
            }

            return vm;
        }

        public GetSingleCourseViewModel GetCourseByIdentifyer(string identifyer)
        {
            var course = _dbContext.Courses
                .Include(c => c.Tutors)
                .Include(c => c.Chapters)
                .FirstOrDefault(c => c.UniqueIdentifyer.ToLower() == identifyer.ToLower());

            GetSingleCourseViewModel vm = new GetSingleCourseViewModel();
            vm.Course = course;

            if (course.Chapters.Count > 0)
            {
                foreach (var chapter in course.Chapters)
                {
                    vm.Chapters.Append(_dbContext.CourseChapters.Include(c => c.Paragraphs).FirstOrDefault(c => c.Id == chapter.Id));
                }
            }

            return vm;
        }

        public async Task<Course> ModifyCourseDeatails(Course course)
        {
            var _course = await _dbContext.Courses.FirstAsync(c => c.Id == course.Id);

            if (_course == null)
                return new Course { Id = Guid.Empty };

            _course.Title = course.Title;
            _course.Summary= course.Summary;

            await _dbContext.SaveChangesAsync();

            return _course;
        }

        public async Task<CourseParagraph> RemoveParagraphFromCourse(CourseParagraph courseParagraph)
        {
            var courseChapter = await _dbContext.CourseChapters.FirstOrDefaultAsync(c => c.Id == courseParagraph.CourseSubTopicId);

            if(courseChapter == null)
                return new CourseParagraph { Id = Guid.Empty };

            _dbContext.CourseParagraphs.Remove(courseParagraph);
            await _dbContext.SaveChangesAsync();
            return courseParagraph;
        }
    }
}
