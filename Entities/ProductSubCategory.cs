namespace Entities;

public class ProductSubCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public required ProductCategory ParentCategory { get; set; }
    public int ParentCategoryId { get; set; }
}