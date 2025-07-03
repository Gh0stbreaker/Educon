using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class SubjectRepository : Repository<Subject>, ISubjectRepository
{
    public SubjectRepository(EduconContext context, ILogger<SubjectRepository> logger) : base(context, logger) { }
}
