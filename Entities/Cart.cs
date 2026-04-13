using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Cart
    {
        private readonly List<Product> _items = new();

        public IReadOnlyList<Product> Items => _items.AsReadOnly();

        public void Add(Product product) => _items.Add(product);

        public void Remove(Product product) => _items.Remove(product);

        public void Clear() => _items.Clear();

        public decimal Total => _items.Sum(p => p.Price);
    }
}
