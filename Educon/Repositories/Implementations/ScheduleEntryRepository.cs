using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class ScheduleEntryRepository : Repository<ScheduleEntry>, IScheduleEntryRepository
{
    public ScheduleEntryRepository(EduconContext context, ILogger<ScheduleEntryRepository> logger) : base(context, logger) { }
}
