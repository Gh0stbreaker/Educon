using Educon.Models;
using Educon.Repositories.Interfaces;
using System.Linq;

namespace Educon.Services.Implementations;

public class AttendanceRecordService : GenericService<AttendanceRecord>, IAttendanceRecordService
{
    private readonly IAttendanceRecordRepository _repository;

    public AttendanceRecordService(IAttendanceRecordRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<AttendanceRecord>> GetRecordsByStudentAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        return _repository.GetAsync(
            r => r.StudentId == studentId,
            cancellationToken: cancellationToken,
            includes: r => r.Student!);
    }
}
