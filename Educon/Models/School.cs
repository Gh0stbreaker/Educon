namespace Educon.Models;

public class School
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public SchoolType Type { get; set; }
    public SchoolLevel Level { get; set; }
    public SchoolStatus Status { get; set; }
    public string Address { get; set; } = null!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Ico { get; set; }
    public string? Director { get; set; }

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
