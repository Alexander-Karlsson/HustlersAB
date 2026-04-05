namespace Entities;

public class ProductCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<ProductSubCategory> SubCategories { get; set; } = [];
}