using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class SchoolYear : IEntity
{
    public Guid Id { get; set; }
    [Required, StringLength(20)]
    public string Name { get; set; } = null!; // Např. "2024/2025"

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
