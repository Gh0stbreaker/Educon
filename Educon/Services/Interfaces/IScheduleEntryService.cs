using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IScheduleEntryService : IGenericService<ScheduleEntry>
{
    Task<IEnumerable<ScheduleEntry>> GetEntriesByClassAsync(
        Guid classId,
        CancellationToken cancellationToken = default);
}
