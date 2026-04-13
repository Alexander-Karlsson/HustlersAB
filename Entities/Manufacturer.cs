namespace Entities;

public class Manufacturer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}