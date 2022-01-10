using System;
using System.Globalization;
using Pedido.Entities;
using Pedido.Entities.Enums;


namespace Pedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            string strDate = date.ToString("dd/MM/yyyy");
           
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

           // DateTime moment = DateTime.Now;
            Client client = new Client(name, email, date);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order?: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                
                Console.WriteLine($"Enter  #{i} item data:");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int qty = int.Parse(Console.ReadLine());

                Product product = new Product(prodName, price);
                OrderItem orderItem = new OrderItem(qty, price, product);

                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            
            Console.WriteLine(order);
            
        }
    }
}
