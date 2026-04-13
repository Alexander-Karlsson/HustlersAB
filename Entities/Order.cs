namespace Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public Guid ShippingId { get; set; }
    public Shipping Shipping { get; set; } = null!;

    public ICollection<ProductOrder> ProductOrders { get; set; } = [];

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;

    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}