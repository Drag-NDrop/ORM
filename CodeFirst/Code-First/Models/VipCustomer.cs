using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Models
{
    [Table("vipCustomers")]
    public class VipCustomer : Customer
    {
        public int DiscountPercent { get; set; }
    }
}
