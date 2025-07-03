using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class GradeLevel : IEntity
{
    public Guid Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; } = null!; // Např. "1. ročník", "9. třída"

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
