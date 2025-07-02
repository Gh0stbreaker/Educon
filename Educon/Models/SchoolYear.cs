namespace Educon.Models;

public class SchoolYear
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!; // Např. "2024/2025"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
