namespace Educon.Models;

public class TeacherSchoolAssignment
{
    public Guid Id { get; set; }

    public Guid TeacherId { get; set; }
    public TeacherProfile Teacher { get; set; } = null!;

    public Guid SchoolId { get; set; }
    public School School { get; set; } = null!;

    public DateTime AssignedFrom { get; set; }
    public DateTime? AssignedTo { get; set; }
}
