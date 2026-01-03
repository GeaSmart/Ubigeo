using Ubigeos.Application.Dtos;
using Ubigeos.Domain.Ubigeos;

namespace Ubigeos.Application.Mappings;

public static class UbigeoMappings
{
    public static UbigeoItemDto ToItemDto(this Ubigeo entity)
        => new()
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name
        };

    public static UbigeoTreeDto ToTreeDto(this Ubigeo entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Children = entity.Children
                .Select(child => child.ToTreeDto())
                .ToList()
        };
}