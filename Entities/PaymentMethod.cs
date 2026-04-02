namespace Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public required string PaymentName { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
