using Microsoft.AspNetCore.Mvc;
using StudentManagerProject.Web.Repository;

namespace StudentManagerProject.Web.Components
{
    public class SubjectsViewComponent : ViewComponent
    {
        private readonly ISubjectRepository _repo;
        public SubjectsViewComponent(ISubjectRepository repo)
        {
            _repo = repo;
        }

        public IViewComponentResult Invoke() 
        {
            var subjectList = _repo.GetAll();
            return View(subjectList);
        }
    }
}
