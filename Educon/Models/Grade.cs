using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class Grade : IEntity
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public Guid SubjectTeacherId { get; set; }
    public SubjectTeacher SubjectTeacher { get; set; } = null!;

    [Required, StringLength(5)]
    public string GradeValue { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime DateAssigned { get; set; }

    [StringLength(250)]
    public string? Note { get; set; }
}
