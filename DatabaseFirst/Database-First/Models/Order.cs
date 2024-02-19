using System;
using System.Collections.Generic;

namespace Database_First.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
