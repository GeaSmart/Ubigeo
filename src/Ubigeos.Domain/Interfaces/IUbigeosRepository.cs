using Ubigeos.Domain.Ubigeos;

namespace Ubigeos.Domain.Interfaces;

public interface IUbigeosRepository
{
    Task<IReadOnlyList<Ubigeo>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Ubigeo>> GetTreeAsync(
        CancellationToken cancellationToken = default);
}