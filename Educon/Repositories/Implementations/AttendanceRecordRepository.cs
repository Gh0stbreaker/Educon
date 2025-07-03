using Educon.Data;
using Educon.Models;
using Microsoft.Extensions.Logging;
using Educon.Repositories.Interfaces;

namespace Educon.Repositories.Implementations;

public class AttendanceRecordRepository : Repository<AttendanceRecord>, IAttendanceRecordRepository
{
    public AttendanceRecordRepository(EduconContext context, ILogger<AttendanceRecordRepository> logger) : base(context, logger) { }
}
