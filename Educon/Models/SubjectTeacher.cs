namespace Educon.Models;

public class SubjectTeacher : IEntity
{
    public Guid Id { get; set; }

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public Guid TeacherId { get; set; }
    public TeacherProfile Teacher { get; set; } = null!;
}
