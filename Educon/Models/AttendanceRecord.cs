using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class AttendanceRecord
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    [StringLength(250)]
    public string? Note { get; set; }
}
