using Microsoft.AspNetCore.Identity;

namespace StudentManagerProject.Web.Models
{
    public class Tutor : IdentityUser
    {
        public List<Course>? Courses { get; set; }
    }
}
