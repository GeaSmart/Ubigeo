using Ubigeos.Application.Dtos;

namespace Ubigeos.Application.Ubigeos;

public interface IUbigeosService
{
    Task<IReadOnlyList<UbigeoItemDto>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<UbigeoTreeDto>> GetTreeAsync(
        CancellationToken cancellationToken = default);
}