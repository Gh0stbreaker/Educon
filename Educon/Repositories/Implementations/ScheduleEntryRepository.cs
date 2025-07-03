using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class ScheduleEntryRepository : Repository<ScheduleEntry>, IScheduleEntryRepository
{
    public ScheduleEntryRepository(EduconContext context, ILogger<ScheduleEntryRepository> logger) : base(context, logger) { }
}
