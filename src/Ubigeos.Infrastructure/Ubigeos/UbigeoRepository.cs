using Microsoft.EntityFrameworkCore;
using Ubigeos.Domain;

namespace Ubigeos.Infrastructure.Ubigeos;

public class UbigeosRepository(ApplicationDbContext context) : IUbigeosRepository
{
    public async Task<IReadOnlyList<Ubigeo>> GetByParentAsync(
        int parentId,
        CancellationToken cancellationToken = default)
    {
        return await context.Set<Ubigeo>()
            .Where(x => x.ParentId == parentId)
            .OrderBy(x => x.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Ubigeo>> GetTreeAsync(
        CancellationToken cancellationToken = default)
    {
        return await context.Set<Ubigeo>()
            .Where(x => x.Level == UbigeoLevel.Department)
            .Include(x => x.Children)
                .ThenInclude(x => x.Children)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}