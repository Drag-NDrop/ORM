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

                // Create
                Customer customer = new Customer();
                customer.Name = "Test";
                context.Customers.Add(customer);
                context.SaveChanges();

                // Read
                List<OrderProductMapping> ordreMapping = context.OrderProductMappings.ToList();
                List<Order> orders                     = context.Orders.ToList();
                List<Product> products                 = context.Products.ToList();
                List<Customer> customers               = context.Customers.ToList();

                // Update
                // orders.FirstOrDefault().Customer.Name = "Test";
                // context.SaveChanges();

                // Delete
                // Customer remove = customers.FirstOrDefault(x => x.Id == 5);
                // context.Customers.Remove(remove);
                // context.SaveChanges();

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

                // Get orders with unique products
                context.Orders.FirstOrDefault().Products.Select(p => p).Distinct().ToList();
                context.Orders.Select(p => p.Products).Distinct().ToList();
            }
        }
    }
}
