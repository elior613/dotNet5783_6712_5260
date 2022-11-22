// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
class dalTest 
{
    static void Main(string args[])
    {
        Console.WriteLine("Which entity do you want ?");
        Console.WriteLine("1-Product");
        Console.WriteLine("2-Order");
        Console.WriteLine("3-OrderItem");
        int choice = 0;
        Console.ReadLine(choice);
        switch(choice)
        {
            case 1:
                Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                Console.WriteLine("-Choose 1 to add a new product.");
                Console.WriteLine("-Choose 2 to get any product");
                Console.WriteLine("-Choose 3 to show all products.").;
                Console.WriteLine("-Choose 4 to delete any product");
                Console.WriteLine("-Choose 5 to update any product");
                switch () 
                {
                
                }
            case 2:
                Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                Console.WriteLine("-Choose 1 to Add a new Order to an existing set.");
                Console.WriteLine("-Choose 2 to show any Order.");
                Console.WriteLine("-Choose 3 to show the whole list of the Orders.");
                Console.WriteLine("-Choose 4 to show details of any Order.");
                Console.WriteLine("-Choose 5 to delete ant Order.");
                Console.WriteLine("-Choose 6 to update ant Order.");
                switch ()
                {

                }

            case 3:
                Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                Console.WriteLine("-Choose 1 to Add a new OrderItem to an existing set.");
                Console.WriteLine("-Choose 2 to show any OrderItem.");
                Console.WriteLine("-Choose 3 to show all the OrderItems.");
                Console.WriteLine("-Choose 4 to show details of any OrderItem by Product ID and Order ID.");
                Console.WriteLine("-Choose 5 to delete ant OrderItem.");
                Console.WriteLine("-Choose 6 to update ant OrderItem.");
                switch ()
                {

                }

        }

        
        
    }
}