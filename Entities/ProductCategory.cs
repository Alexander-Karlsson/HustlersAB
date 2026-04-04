namespace Entities;

public class ProductCategory
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<ProductSubCategory> SubCategories { get; set; } = [];
}