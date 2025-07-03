using Educon.Models;

namespace Educon.Services.Interfaces;

public interface IStudyFieldService : IGenericService<StudyField>
{
    Task<IEnumerable<StudyField>> GetByTypeAsync(
        StudyFieldType type,
        CancellationToken cancellationToken = default);
}
