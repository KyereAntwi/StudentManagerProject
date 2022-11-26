using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagerProject.Web.Models;
using StudentManagerProject.Web.Repository;

namespace StudentManagerProject.Web.Pages
{
    public class CoursesModel : PageModel
    {
        public IEnumerable<Course> courses = new List<Course>();
        
        private readonly ICourseRepository courseRepository;

        public CoursesModel(ICourseRepository repo)
        {
            courseRepository = repo;
        }

        public void OnGet(string queryString)
        {
            courses = courseRepository.GelAllCourses();
        }
    }
}
