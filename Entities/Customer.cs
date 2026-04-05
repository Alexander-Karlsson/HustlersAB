namespace Entities;

public class Customer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public bool IsMember { get; set; } // Skapa egen tabell?

    public required CustomerContactInfo? ContactInfo { get; set; }
}