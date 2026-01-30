using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("12 Main Street", "Lagos", "Lagos", "Nigeria");
        Customer customer1 = new Customer("Emem Tom", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 10.0, 2));
        order1.AddProduct(new Product("Pen", "P010", 1.5, 5));

        Address address2 = new Address("45 Elm Street", "Dallas", "Texas", "USA");
        Customer customer2 = new Customer("John Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N777", 5.0, 3));
        order2.AddProduct(new Product("Backpack", "BP99", 25.0, 1));

        Console.WriteLine("ORDER 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}");

        Console.WriteLine("\nORDER 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}");
    }
}
