using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class StudentParentRepository : Repository<StudentParent>, IStudentParentRepository
{
    public StudentParentRepository(EduconContext context, ILogger<StudentParentRepository> logger) : base(context, logger) { }
}
