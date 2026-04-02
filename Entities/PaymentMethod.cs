using System;
using System.Collections.Generic;
using System.Text;

namespace Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
