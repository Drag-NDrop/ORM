using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public int CustomerId { get; set; }
    }
}
