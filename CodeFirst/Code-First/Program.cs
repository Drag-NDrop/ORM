using Code_First.DataContext;
using Code_First.Models;
using Code_First.Repositories;

namespace Code_First
{
    public class Program
    {
        static void Main(string[] args)
        {

            ConsoleKey key;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1: Customers\n2: Orders\n3: Products \n4: Mappings\n");

                key = Console.ReadKey().Key;
                using (Context context = new Context())
                {
                    try
                    {
                        switch (key)
                        {

                            case ConsoleKey.D1:
                                CustomerRepo customerRepo = new CustomerRepo();
                                List<Customer> customerList = customerRepo.Customers().ToList();
                                foreach (Customer customerItem in customerList)
                                {
                                    Console.WriteLine($"{customerItem.Id}: {customerItem.Name}");
                                }
                                Console.WriteLine("1: Create\n2: Edit\n3:Delete\n");
                                key = Console.ReadKey().Key;
                                switch (key)
                                {
                                    case ConsoleKey.D1:
                                        Console.Write("Indtast nyt kundenavn: ");
                                        string cName = Console.ReadLine();

                                        Console.WriteLine("\n1: Normal Kunde\n2: VIP Kunde");
                                        key = Console.ReadKey().Key;
                                        if (key == ConsoleKey.D1)
                                        {
                                            Customer customer = new Customer()
                                            {
                                                Name = cName
                                            };
                                            customerRepo.New(customer);
                                            successfulMessage("Customer has been created");

                                        }
                                        else if (key == ConsoleKey.D2)
                                        {
                                            Console.WriteLine("\nEnter discount percent");
                                            int vipCustomerPercent = Int32.Parse(Console.ReadLine());
                                            VipCustomer customer = new VipCustomer()
                                            {
                                                DiscountPercent = vipCustomerPercent,
                                                Name = cName
                                            };
                                            customerRepo.New(customer);

                                            successfulMessage("VIP Customer has been created");
                                        }

                                        ExitGuiPrompt();
                                        break;

                                    case ConsoleKey.D2:
                                        Console.WriteLine("Indtast kunde-id");
                                        int editCustomerId = Int32.Parse(Console.ReadLine());

                                        Console.WriteLine("Skriv et nyt navn");
                                        string editCustomerName = Console.ReadLine();
                                        Console.WriteLine("Er du sikker du vil lave disse ændringer? Y/N");

                                        if (Console.ReadKey().Key == ConsoleKey.Y)
                                        {
                                            customerRepo.Edit(editCustomerId, editCustomerName);
                                            successfulMessage("Customer has been editted");

                                        }

                                        ExitGuiPrompt();

                                        break;
                                    case ConsoleKey.D3:
                                        Console.WriteLine("Indtast kunde-id");
                                        int deleteCustomerId = Int32.Parse(Console.ReadLine());
                                        Console.WriteLine("Er du sikker du vil slette? Y/N");

                                        if (Console.ReadKey().Key == ConsoleKey.Y)
                                        {
                                            customerRepo.Delete(deleteCustomerId);
                                            successfulMessage("Customer has been deleted");

                                        }

                                        ExitGuiPrompt();
                                        break;

                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nUgyldig input");
                    }
                }
            } while (key != ConsoleKey.D0);
        }
        private static void ExitGuiPrompt()
        {
            Console.WriteLine("\nTryk på en tast for at komme videre");
            Console.ReadKey();
            Console.Clear();
        }

        private static void successfulMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
