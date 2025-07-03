using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class StudentProfile : IEntity
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;

    public Guid? ClassId { get; set; }
    public SchoolClass? Class { get; set; }

    [DataType(DataType.Date)]
    public DateTime EnrollmentDate { get; set; }
    public StudentType StudentType { get; set; } = StudentType.Regular;
    public StudentStatus StudentStatus { get; set; } = StudentStatus.Active;
    public StudentNeedType StudentNeedType { get; set; } = StudentNeedType.None;
    public ICollection<StudentParent> ParentsLinks { get; set; } = new List<StudentParent>();
}
