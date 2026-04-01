namespace Entities;

public class ProductCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<ProductSubCategory> SubCategories { get; set; } = [];
}