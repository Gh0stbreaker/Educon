namespace Educon.Models;

public class Grade
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public Guid SubjectTeacherId { get; set; }
    public SubjectTeacher SubjectTeacher { get; set; } = null!;

    public string GradeValue { get; set; } = null!;
    public DateTime DateAssigned { get; set; }
    public string? Note { get; set; }
}
