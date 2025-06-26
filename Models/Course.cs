namespace GenieWeb.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
