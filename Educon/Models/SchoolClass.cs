using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class SchoolClass
{
    public Guid? SchoolYearId { get; set; }
    public SchoolYear? SchoolYear { get; set; }
    public Guid Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; } = null!;

    public Guid? HomeroomTeacherId { get; set; }
    public TeacherProfile? HomeroomTeacher { get; set; }

    public Guid? GradeLevelId { get; set; }
    public GradeLevel? GradeLevel { get; set; }

    public Guid? SchoolId { get; set; }
    public School? School { get; set; }

    public Guid? StudyFieldId { get; set; }
    public StudyField? StudyField { get; set; }

    public ClassType ClassType { get; set; } = ClassType.Standard;
    public ICollection<StudentProfile> Students { get; set; } = new List<StudentProfile>();
}
