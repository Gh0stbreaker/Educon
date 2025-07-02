namespace Educon.Models;

public class Profile
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public ApplicationUser User { get; set; } = null!;
    public StudentProfile? StudentProfile { get; set; }
    public TeacherProfile? TeacherProfile { get; set; }
    public ParentProfile? ParentProfile { get; set; }
}
