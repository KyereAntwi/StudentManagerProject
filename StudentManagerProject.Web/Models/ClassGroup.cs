namespace StudentManagerProject.Web.Models
{
    public class ClassGroup
    {
        public Guid id { get; set; }
        public string GroupIdentity { get; set; } = string.Empty;

        public List<Student>? Students { get; set; }
    }
}
