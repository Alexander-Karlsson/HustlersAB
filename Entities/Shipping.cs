namespace Entities;

public class Shipping
{
    public Guid Id { get; set; }
    public required string TypeOfShipping { get; set; }
    public decimal Price { get; set; }
}