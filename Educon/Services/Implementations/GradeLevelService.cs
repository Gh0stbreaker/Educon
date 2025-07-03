using System.Linq;
using Educon.Models;
using Educon.Repositories.Interfaces;

namespace Educon.Services.Implementations;

public class GradeLevelService : GenericService<GradeLevel>, IGradeLevelService
{
    private readonly IGradeLevelRepository _repository;

    public GradeLevelService(IGradeLevelRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<GradeLevel?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(gl => gl.Name == name, cancellationToken: cancellationToken);
        return result.FirstOrDefault();
    }
}
