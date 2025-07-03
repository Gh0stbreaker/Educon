using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;

namespace Educon.Repositories.Implementations;

public class AttendanceRecordRepository : Repository<AttendanceRecord>, IAttendanceRecordRepository
{
    public AttendanceRecordRepository(EduconContext context, ILogger<AttendanceRecordRepository> logger) : base(context, logger) { }
}
