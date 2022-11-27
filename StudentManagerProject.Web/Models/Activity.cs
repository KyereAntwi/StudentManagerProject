namespace StudentManagerProject.Web.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
    }
}
