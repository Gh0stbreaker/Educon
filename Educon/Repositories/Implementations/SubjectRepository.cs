using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class SubjectRepository : Repository<Subject>, ISubjectRepository
{
    public SubjectRepository(EduconContext context, ILogger<SubjectRepository> logger) : base(context, logger) { }
}
