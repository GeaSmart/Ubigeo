namespace Ubigeos.Domain;

public interface IUbigeosRepository
{
    Task<IReadOnlyList<Ubigeo>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Ubigeo>> GetTreeAsync(
        CancellationToken cancellationToken = default);
}