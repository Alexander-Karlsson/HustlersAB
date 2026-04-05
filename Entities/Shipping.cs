namespace Entities;

public class Shipping
{
    public Guid Id { get; set; }
    public string TypeOfShipping { get; set; } = null!;
    public decimal Price { get; set; }
}