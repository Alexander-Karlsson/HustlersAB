namespace Entities;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int QtyInStock { get; set; }
    public Guid SubCategoryId { get; set; }
    public required ProductSubCategory SubCategory { get; set; }
    public Offer? Offer { get; set; }

    public ICollection<ProductOrder> ProductOrders { get; set; }
}