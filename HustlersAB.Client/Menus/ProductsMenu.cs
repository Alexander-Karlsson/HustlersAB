using Entities;
using HustlersAB.Shared.Menus;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Services.Interfaces.Products;

namespace HustlersAB.Client.Menus;

public class ProductsMenu(IProductService service) : BaseMenu
{
    private List<Product> _products = [];
    private int _page = 0;
    private const int PageSize = 25;

    protected override string[] Options
    {
        get
        {
            if (_products.Count == 0)
                _products = service.GetAllAsync().GetAwaiter().GetResult().ToList();
            
            var paged = _products.Skip(_page * PageSize).Take(PageSize).ToList();
            var options = paged.Select(p => $"{p.Name} - {p.Price:F2}Kr").ToList();
            
            if((_page + 1) * PageSize < _products.Count)
                options.Add("\nNext Page →");
            
            if(_page > 0)
                options.Add("← Previous Page");

            return options.ToArray();
        }
    }

    protected override bool ExecuteChoice(int selectedIndex)
    {
        var paged = _products.Skip(_page * PageSize).Take(PageSize).ToList();
        int nextPage = paged.Count; 
        int prevPage = paged.Count + ((_page + 1) * PageSize < _products.Count ? 1 : 0);

        if ((_page + 1) * PageSize < _products.Count && selectedIndex == nextPage)
        {
            _page++;
            SelectedIndex = 0;
            return false;
        }

        if (_page > 0 && selectedIndex == prevPage)
        {
            _page--;
            SelectedIndex = 0;
            return false;
        }

        ShowProductDetails(paged[selectedIndex]);
        Console.ReadKey(true);
        return false;
    }

    private void ShowProductDetails(Product product)
    {
        Console.Clear();
        Console.WriteLine("PRODUCT DETAILS:\n");
        Console.WriteLine($"NAME: {product.Name} - PRICE: {product.Price}Kr\n");
        Console.WriteLine($"DESCRIPTION:\n{product.Description}\n");
        Console.WriteLine($"IN STOCK: {product.QtyInStock}st");
        Console.WriteLine("\nPess [Enter] to add to your cart. Press [Esc] to go back.");
    }
}

