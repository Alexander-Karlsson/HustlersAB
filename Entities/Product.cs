namespace Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int QtyInStock { get; set; }
    
    public Guid ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = null!;
    public Guid SubCategoryId { get; set; }
    public ProductSubCategory SubCategory { get; set; } = null!;
    public Offer? Offer { get; set; }

    public ICollection<ProductOrder> ProductOrders { get; set; } = [];
}