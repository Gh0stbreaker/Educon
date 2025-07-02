namespace Educon.Models;

public class AttendanceRecord
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public string? Note { get; set; }
}
