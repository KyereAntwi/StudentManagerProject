using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagerProject.Web.Models;

namespace StudentManagerProject.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubjectRecord> StudentSubjectRecords { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<CourseSubTopic> CourseChapters { get; set; }
        public DbSet<CourseParagraph> CourseParagraphs { get; set; }

    }
}
