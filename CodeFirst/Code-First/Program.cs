using Code_First.DataContext;
using Code_First.Models;

namespace Code_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Name = "Test";

            VipCustomer vipCustomer = new VipCustomer();
            vipCustomer.Name = "vipTest";

            Context context = new Context();

            context.Add(vipCustomer);
            context.SaveChanges();


        }
    }
}
