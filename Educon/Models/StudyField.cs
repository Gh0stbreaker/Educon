using System.ComponentModel.DataAnnotations.Schema;

namespace Educon.Models;

public class StudyField
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!; // Číslo studijního oboru
    public string Name { get; set; } = null!;
    public StudyFieldType Type { get; set; }

    public ICollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();
}
