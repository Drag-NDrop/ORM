using Code_First.DataContext;
using Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Repositories
{
    public class CustomerRepo
    {

        public void New(Customer customer)
        {
            using (Context context = new Context())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
        public ICollection<Customer> Customers()
        {
            using (Context context = new Context())
            {
                return context.Customers.ToList();
            }
        }
        public void Edit(int id, string newName)
        {
            using (Context context = new Context())
            {
                context.Customers.FirstOrDefault(x => x.Id == id).Name = newName;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (Context context = new Context())
            {
                context.Customers.Remove(context.Customers.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
            }
        }


        // Vip customers

        public void New(VipCustomer customer)
        {
            using (Context context = new Context())
            {
                context.VipCustomers.Add(customer);
                context.SaveChanges();
            }
        }

    }
}
