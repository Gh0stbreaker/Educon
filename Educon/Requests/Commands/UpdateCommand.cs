using Educon.Repositories;
using MediatR;

namespace Educon.Requests.Commands;

public record UpdateCommand<T>(T Entity) : IRequest where T : class;

public class UpdateCommandHandler<T> : IRequestHandler<UpdateCommand<T>> where T : class
{
    private readonly IRepository<T> _repository;

    public UpdateCommandHandler(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.Entity);
    }
}
