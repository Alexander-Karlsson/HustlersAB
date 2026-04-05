namespace Entities;

public class Offer
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal NewPrice { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
