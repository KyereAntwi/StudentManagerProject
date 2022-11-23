using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagerProject.Web.Models
{
    public class Student : IdentityUser
    {
        public Guid ClassGroupId { get; set; }
        [ForeignKey("ClassGroupId")]
        public ClassGroup ClassGroup { get; set; } = default!;

        public List<StudentSubjectRecord>? Records { get; set; }
    }
}
