namespace Entities;

public class Offer
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    public decimal NewPrice { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
