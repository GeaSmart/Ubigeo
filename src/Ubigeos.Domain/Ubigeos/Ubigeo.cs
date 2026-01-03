namespace Ubigeos.Domain.Ubigeos;

public class Ubigeo
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public UbigeoLevel Level { get; set; }

    public int? ParentId { get; set; }
    public Ubigeo? Parent { get; set; }

    public ICollection<Ubigeo> Children { get; set; } = new List<Ubigeo>();
}