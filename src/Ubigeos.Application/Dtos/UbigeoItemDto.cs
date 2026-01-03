namespace Ubigeos.Application.Dtos;

public sealed record UbigeoItemDto
{
    public int Id { get; init; }
    public string Code { get; init; } = default!;
    public string Name { get; init; } = default!;
}