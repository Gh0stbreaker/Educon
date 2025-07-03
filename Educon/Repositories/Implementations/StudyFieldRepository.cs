using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class StudyFieldRepository : Repository<StudyField>, IStudyFieldRepository
{
    public StudyFieldRepository(EduconContext context, ILogger<StudyFieldRepository> logger) : base(context, logger) { }
}
