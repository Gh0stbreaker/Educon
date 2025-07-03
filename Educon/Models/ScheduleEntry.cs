using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class ScheduleEntry : IEntity
{
    public Guid Id { get; set; }

    public Guid SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;

    public Guid SubjectTeacherId { get; set; }
    public SubjectTeacher SubjectTeacher { get; set; } = null!;

    public DayOfWeek Day { get; set; }
    [DataType(DataType.Time)]
    public TimeSpan StartTime { get; set; }

    [DataType(DataType.Time)]
    public TimeSpan EndTime { get; set; }

    [StringLength(50)]
    public string? Room { get; set; }
}
