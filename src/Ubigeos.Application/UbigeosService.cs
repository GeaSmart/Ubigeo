using Ubigeos.Domain;

namespace Ubigeos.Application;

public class UbigeosService : IUbigeosService
{
    private readonly IUbigeosRepository _repository;

    public UbigeosService(IUbigeosRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Ubigeo>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken = default)
        => _repository.GetByParentAsync(parentId, cancellationToken);

    public Task<IReadOnlyList<Ubigeo>> GetTreeAsync(
        CancellationToken cancellationToken = default)
        => _repository.GetTreeAsync(cancellationToken);
}