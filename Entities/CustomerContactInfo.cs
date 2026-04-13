namespace Entities;

public class CustomerContactInfo
{
    public Guid Id { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostalNumber { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}