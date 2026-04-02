namespace Entities;

public class CustomerContactInfo
{
    public Guid Id { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public required string PostalNumber { get; set; }
    
    public Guid CustomerId { get; set; }
    public required Customer Customer { get; set; }
}