namespace Educon.Models;

public class GradeLevel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!; // Např. "1. ročník", "9. třída"

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
