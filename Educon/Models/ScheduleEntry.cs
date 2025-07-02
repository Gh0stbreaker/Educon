namespace Educon.Models;

public class ScheduleEntry
{
    public Guid Id { get; set; }

    public Guid SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;

    public Guid SubjectTeacherId { get; set; }
    public SubjectTeacher SubjectTeacher { get; set; } = null!;

    public DayOfWeek Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public string? Room { get; set; }
}
