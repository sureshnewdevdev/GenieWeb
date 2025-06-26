using GenieWeb.Models;

public class User
{
    public int UserId { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    public string Status { get; set; } = "Inactive";
    public string? ActivationToken { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
