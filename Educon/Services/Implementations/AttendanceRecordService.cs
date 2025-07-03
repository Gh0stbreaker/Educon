using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class AttendanceRecordService : GenericService<AttendanceRecord>, IAttendanceRecordService
{
    public AttendanceRecordService(IAttendanceRecordRepository repository) : base(repository) { }
}
