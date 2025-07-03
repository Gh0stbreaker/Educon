using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IGradeService : IGenericService<Grade>
{
    Task<IEnumerable<Grade>> GetGradesByStudentAsync(
        Guid studentId,
        CancellationToken cancellationToken = default);
}
