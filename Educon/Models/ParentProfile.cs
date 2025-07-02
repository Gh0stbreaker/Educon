using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class ParentProfile
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;

    [Phone]
    public string? EmergencyContact { get; set; }
    public ICollection<StudentParent> ChildrenLinks { get; set; } = new List<StudentParent>();
}
