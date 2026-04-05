namespace Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsMember { get; set; }

    public CustomerContactInfo? CustomerContactInfo { get; set; }
}