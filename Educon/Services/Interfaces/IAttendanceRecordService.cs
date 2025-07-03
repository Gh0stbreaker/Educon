using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IAttendanceRecordService : IGenericService<AttendanceRecord>
{
    Task<IEnumerable<AttendanceRecord>> GetRecordsByStudentAsync(
        Guid studentId,
        CancellationToken cancellationToken = default);
}
