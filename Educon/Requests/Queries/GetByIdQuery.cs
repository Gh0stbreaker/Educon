using Educon.Repositories;
using MediatR;

namespace Educon.Requests.Queries;

public record GetByIdQuery<T>(Guid Id) : IRequest<T?> where T : class;

public class GetByIdQueryHandler<T> : IRequestHandler<GetByIdQuery<T>, T?> where T : class
{
    private readonly IRepository<T> _repository;

    public GetByIdQueryHandler(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T?> Handle(GetByIdQuery<T> request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
