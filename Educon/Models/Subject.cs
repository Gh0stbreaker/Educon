namespace Educon.Models;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public SubjectType SubjectType { get; set; } = SubjectType.Compulsory;
    public ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
