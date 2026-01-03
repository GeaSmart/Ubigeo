using Ubigeos.Domain;

namespace Ubigeos.Application;

public interface IUbigeosService
{
    Task<IReadOnlyList<Ubigeo>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Ubigeo>> GetTreeAsync(
        CancellationToken cancellationToken = default);
}