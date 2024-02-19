using System;
using System.Collections.Generic;

namespace Database_First.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Make { get; set; } = null!;

    public decimal Price { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }
}
