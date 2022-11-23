namespace StudentManagerProject.Web.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UniqueIdentifyer { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
