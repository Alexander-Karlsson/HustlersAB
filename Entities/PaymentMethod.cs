namespace Entities;

public class PaymentMethod
{
    public Guid Id { get; set; }
    public string PaymentName { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = [];
}
