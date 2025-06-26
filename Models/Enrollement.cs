using System;

namespace GenieWeb.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }

        public int CourseId { get; set; }
        public required Course Course { get; set; }

        public DateTime EnrolledOn { get; set; }
    }
}
