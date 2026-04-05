namespace Entities;

public class ProductSubCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    public Guid ParentCategoryId { get; set; }
    public ProductCategory ParentCategory { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = [];
}