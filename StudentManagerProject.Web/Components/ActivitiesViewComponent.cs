using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagerProject.Web.Repository;
using StudentManagerProject.Web.ViewModels;

namespace StudentManagerProject.Web.Components
{
    public class ActivitiesViewComponent : ViewComponent
    {
        private readonly UserManager<IdentityUser> _signInManager;
        private readonly ICourseActivitiesRepository activitiesRepository;
        public ActivitiesViewComponent(UserManager<IdentityUser> signInManager, ICourseActivitiesRepository repo)
        {
            _signInManager = signInManager;
            activitiesRepository = repo;
        }

        public IViewComponentResult Invoke() 
        {
            var activities = activitiesRepository.GetCourseActivitesByTutor(_signInManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User));
            
            ActivitiesViewModel vm = new ActivitiesViewModel();
            vm.CourseActivities = activities;

            return View(vm);
        }
    }
}
