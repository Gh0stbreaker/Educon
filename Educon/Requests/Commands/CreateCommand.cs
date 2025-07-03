using Educon.Repositories;
using MediatR;

namespace Educon.Requests.Commands;

public record CreateCommand<T>(T Entity) : IRequest<T> where T : class;

public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, T> where T : class
{
    private readonly IRepository<T> _repository;

    public CreateCommandHandler(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
    {
        return await _repository.AddAsync(request.Entity, cancellationToken);
    }
}
