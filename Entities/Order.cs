using System.Security.AccessControl;

namespace Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid ShippingId { get; set; }
    public Shipping Shipping { get; set; }

    public ICollection<ProductOrder> ProductOrders { get; set; }

    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public decimal TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; }
}
