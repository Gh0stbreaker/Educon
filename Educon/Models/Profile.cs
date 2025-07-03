using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class Profile : IEntity
{
    public Guid Id { get; set; }
    [Required, StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Required, StringLength(100)]
    public string LastName { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    public ApplicationUser User { get; set; } = null!;
    public StudentProfile? StudentProfile { get; set; }
    public TeacherProfile? TeacherProfile { get; set; }
    public ParentProfile? ParentProfile { get; set; }
}
