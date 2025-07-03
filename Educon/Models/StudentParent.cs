namespace Educon.Models;

public class StudentParent : IEntity
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public Guid ParentId { get; set; }
    public ParentProfile Parent { get; set; } = null!;

    public RelationshipType Relationship { get; set; } = RelationshipType.Other;
}
