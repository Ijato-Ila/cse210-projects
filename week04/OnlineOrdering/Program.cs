using System;

class Program
{
    static void Main()
    {
        // Create Addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create Customers
        Customer customer1 = new Customer("Olly Venus", address1);
        Customer customer2 = new Customer("Anastasia Dang", address2);

        // Create Orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 1200.00, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.99, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "S789", 999.99, 1));
        order2.AddProduct(new Product("Charger", "C101", 19.99, 3));

        // Display Order Details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}
