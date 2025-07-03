using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educon.Models;

public class StudyField : IEntity
{
    public Guid Id { get; set; }
    [Required, StringLength(20)]
    public string Code { get; set; } = null!; // Číslo studijního oboru

    [Required, StringLength(100)]
    public string Name { get; set; } = null!;
    public StudyFieldType Type { get; set; }

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
