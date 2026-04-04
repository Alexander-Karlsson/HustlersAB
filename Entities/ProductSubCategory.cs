namespace Entities;

public class ProductSubCategory
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid ParentCategoryId { get; set; }
    public required ProductCategory ParentCategory { get; set; }
    public ICollection<Product> Products { get; set; } = [];
}