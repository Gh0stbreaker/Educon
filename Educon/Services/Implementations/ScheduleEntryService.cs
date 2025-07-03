using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class ScheduleEntryService : GenericService<ScheduleEntry>, IScheduleEntryService
{
    private readonly IScheduleEntryRepository _repository;

    public ScheduleEntryService(IScheduleEntryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ScheduleEntry>> GetEntriesByClassAsync(Guid classId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            e => e.SchoolClassId == classId,
            cancellationToken: cancellationToken,
            includes: e => e.SchoolClass!, e => e.SubjectTeacher);
    }
}
