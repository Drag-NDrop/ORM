using Database_First.Models;

namespace Database_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var context = new Contexts.TestingContext())
            {
                var vipCustomers = context.VipCustomers.ToList();

           
                       // Console.WriteLine(v.IdNavigation.Name);
                        Console.WriteLine();
                Customer c = context.Customers.FirstOrDefault();
                var test = context.VipCustomers.FirstOrDefault(v => v.IdNavigation == c);


                List<OrderProductMapping> ordreMapping = context.OrderProductMappings.ToList();
                List<Order> orders = context.Orders.ToList();
                List<Product> products = context.Products.ToList();
                List<Customer> customers = context.Customers.ToList();

                foreach (Order o in orders)
                {


                    Console.WriteLine(
                        "Id: " + o.CustomerId.ToString() + Environment.NewLine +
                        "Name: " + o.Customer.Name + Environment.NewLine
                    );
                    List<OrderProductMapping> result = context.OrderProductMappings.Where(opm => opm.OrderId == o.Id).ToList();

                    foreach (OrderProductMapping opm in result) 
                    {
                       List<Product> productrange =  products.Select(p => p).Where(p => p.Id == opm.ProductId).ToList();
                        foreach (Product item in productrange)
                        {
                            Console.WriteLine("Product: " + item.Name);
                        }
                    }
                }

                Console.WriteLine(c.Name);

            }
        }
    }
}
