namespace Educon.Models;

public class TeacherProfile
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;

    public string Department { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public TeacherType TeacherType { get; set; } = TeacherType.Main;
    public TeacherStatus TeacherStatus { get; set; } = TeacherStatus.Active;
}
