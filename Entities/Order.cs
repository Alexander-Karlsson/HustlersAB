namespace Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public int ShippingId { get; set; }
    public Shipping Shipping { get; set; }
    
    public int ProductId { get; set; }
    public ICollection<Product> Products { get; set; }
    
    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    
    public decimal TotalPrice { get; set; }
}
