using Ubigeos.Application.Dtos;
using Ubigeos.Domain;

namespace Ubigeos.Application;

public interface IUbigeosService
{
    Task<IReadOnlyList<UbigeoItemDto>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<UbigeoTreeDto>> GetTreeAsync(
        CancellationToken cancellationToken = default);
}