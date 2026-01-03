namespace Ubigeos.Application.Dtos;

public sealed record UbigeoTreeDto
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public IReadOnlyList<UbigeoTreeDto> Children { get; init; }
        = Array.Empty<UbigeoTreeDto>();
}