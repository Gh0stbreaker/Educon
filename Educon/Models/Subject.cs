using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class Subject : IEntity
{
    public Guid Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; } = null!;

    public SubjectType SubjectType { get; set; } = SubjectType.Compulsory;
    public ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
