using Educon.Repositories;
using MediatR;

namespace Educon.Requests.Commands;

public record DeleteCommand<T>(Guid Id) : IRequest where T : class;

public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>> where T : class
{
    private readonly IRepository<T> _repository;

    public DeleteCommandHandler(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
    }
}
