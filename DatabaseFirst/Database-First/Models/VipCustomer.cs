using System;
using System.Collections.Generic;

namespace Database_First.Models;

public partial class VipCustomer
{
    public int Id { get; set; }

    public int DiscountPercent { get; set; }

    public virtual Customer IdNavigation { get; set; } = null!;
}
