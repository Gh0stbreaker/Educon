using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IGradeLevelService : IGenericService<GradeLevel>
{
    Task<GradeLevel?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken = default);
}
