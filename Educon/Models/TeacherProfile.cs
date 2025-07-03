using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class TeacherProfile : IEntity
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;

    [Required, StringLength(100)]
    public string Department { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; }
    public TeacherType TeacherType { get; set; } = TeacherType.Main;
    public TeacherStatus TeacherStatus { get; set; } = TeacherStatus.Active;
}
