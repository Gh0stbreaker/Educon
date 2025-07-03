using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class StudentParentRepository : Repository<StudentParent>, IStudentParentRepository
{
    public StudentParentRepository(EduconContext context, ILogger<StudentParentRepository> logger) : base(context, logger) { }
}
