using System.ComponentModel.DataAnnotations;

namespace Educon.Models;

public class School
{
    public Guid Id { get; set; }
    [Required, StringLength(200)]
    public string Name { get; set; } = null!;
    public SchoolType Type { get; set; }
    public SchoolLevel Level { get; set; }
    public SchoolStatus Status { get; set; }
    [Required, StringLength(300)]
    public string Address { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Phone { get; set; }

    [StringLength(50)]
    public string? Ico { get; set; }
    [StringLength(100)]
    public string? Director { get; set; }

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
