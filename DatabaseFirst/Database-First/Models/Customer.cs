using System;
using System.Collections.Generic;

namespace Database_First.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual VipCustomer? VipCustomer { get; set; }
}
