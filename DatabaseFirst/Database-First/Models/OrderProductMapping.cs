using System;
using System.Collections.Generic;

namespace Database_First.Models;

public partial class OrderProductMapping
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
