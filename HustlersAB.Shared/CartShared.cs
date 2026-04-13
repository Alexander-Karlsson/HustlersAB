using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HustlersAB.Shared;

public class CartShared()
{
    private readonly List<Product> _items = new List<Product>();

    public IReadOnlyList<Product> Items => _items.AsReadOnly();

    public void Add(Product product) => _items.Add(product);

    public void Remove(Product product) => _items.Remove(product);

    public void Clear() => _items.Clear();

    public decimal Total => _items.Sum(p => p.Price);
}
