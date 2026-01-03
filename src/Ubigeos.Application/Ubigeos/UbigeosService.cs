using Ubigeos.Application.Dtos;
using Ubigeos.Application.Mappings;
using Ubigeos.Domain.Interfaces;

namespace Ubigeos.Application.Ubigeos;

public class UbigeosService : IUbigeosService
{
    private readonly IUbigeosRepository _repository;

    public UbigeosService(IUbigeosRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<UbigeoItemDto>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken)
    {
        var entities = await _repository.GetByParentAsync(parentId, cancellationToken);
        return entities.Select(x => x.ToItemDto()).ToList();
    }

    public async Task<IReadOnlyList<UbigeoTreeDto>> GetTreeAsync(
    CancellationToken cancellationToken)
    {
        var entities = await _repository.GetTreeAsync(cancellationToken);
        return entities.Select(x => x.ToTreeDto()).ToList();
    }
}