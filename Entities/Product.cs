namespace Entities;

public class Product
{
    public int Id { get; private set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int QtyInStock { get; set; }
    public required ProductSubCategory SubCategory { get; set; }
    public int SubCategoryId { get; set; }
    public Offer Offer { get; set; }
}