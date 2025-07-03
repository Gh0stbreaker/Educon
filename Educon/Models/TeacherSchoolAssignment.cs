using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class TeacherSchoolAssignment : IEntity
{
    public Guid Id { get; set; }

    public Guid TeacherId { get; set; }
    public TeacherProfile Teacher { get; set; } = null!;

    public Guid SchoolId { get; set; }
    public School School { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime AssignedFrom { get; set; }

    [DataType(DataType.Date)]
    public DateTime? AssignedTo { get; set; }
}
