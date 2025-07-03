using System.Linq;
using Educon.Models;
using Educon.Repositories.Interfaces;
using Educon.Services.Interfaces;

namespace Educon.Services.Implementations;

public class SchoolYearService : GenericService<SchoolYear>, ISchoolYearService
{
    private readonly ISchoolYearRepository _repository;

    public SchoolYearService(ISchoolYearRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<SchoolYear?> GetCurrentYearAsync(CancellationToken cancellationToken = default)
    {
        var today = DateTime.UtcNow.Date;
        var result = await _repository.GetAsync(
            y => y.StartDate <= today && y.EndDate >= today,
            cancellationToken: cancellationToken);
        return result.FirstOrDefault();
    }
}
