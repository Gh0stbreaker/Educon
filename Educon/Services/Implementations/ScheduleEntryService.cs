using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class ScheduleEntryService : GenericService<ScheduleEntry>, IScheduleEntryService
{
    public ScheduleEntryService(IScheduleEntryRepository repository) : base(repository) { }
}
