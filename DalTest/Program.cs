// See https://aka.ms/new-console-template for more information

using Dal;
using DO;
#nullable disable


class DalTest
{
    static void Main(string[] args)
    {
        DalProduct dalProduct = new DalProduct();
        DalOrder dalOrder = new DalOrder();
        DalOrderItem dalOrderItem = new DalOrderItem();
        Product product = new Product();
        Product[] products = new Product[50];
        Order[]orders=new Order[100];
        OrderItem[] items=new OrderItem[200];
        List<string> details=new List<string>();
        Order order = new Order();
        OrderItem orderitem = new OrderItem();

        int choice = 1;
        while (choice != 0)
        {
            Console.WriteLine("Which entity do you want ?");
            Console.WriteLine("1-Product");
            Console.WriteLine("2-Order");
            Console.WriteLine("3-OrderItem");
            Console.WriteLine("0-to end the program");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                    Console.WriteLine("-Choose 1 to add a new product.");
                    Console.WriteLine("-Choose 2 to get any product");
                    Console.WriteLine("-Choose 3 to show all products.");
                    Console.WriteLine("-Choose 4 to delete any product");
                    Console.WriteLine("-Choose 5 to update any product");
                    Console.WriteLine("-Choose another number to return to the menu");
                    choice = Convert.ToInt32(Console.ReadLine());
                    int num, num2;
                    DO.Product prod = new DO.Product();
                    Furniture furniture = new Furniture();
                    string category, name, email, address;
                    DateTime date;
                    switch (choice)
                    {

                        case 1:
                            dalProduct.Add(prod);
                            break;
                        case 2:
                            Console.WriteLine("enter the ID of the product you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                product = dalProduct.Get(num);
                                Console.WriteLine(product.ToString());
                            }
                            catch
                            {
                                Console.WriteLine("the product doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        case 3:
                           products= dalProduct.GetAll();
                            foreach(Product p in products)
                            {
                                Console.WriteLine(p.ToString());
                            }
                            break;
                        case 4:
                            Console.WriteLine("enter the ID of the product you want do delete ");
                            num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                dalProduct.Delete(num);
                            }
                            catch
                            {
                                Console.WriteLine("the product doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        case 5:
                            Console.WriteLine("enter Id of the product you want to update");
                            num = Convert.ToInt32(Console.ReadLine());
                            prod.ID = num;
                            Console.WriteLine("which category you want to update? choice: LivingRoomFurniture/bedroomFurniture/kitchenFurniture/toilets/officeFurniture");
                            category = System.Console.ReadLine();
                            furniture.ToString(category);
                            Console.WriteLine("hou many there is in stock?");
                            num = Convert.ToInt32(Console.ReadLine());
                            prod.InStock = num;
                            Console.WriteLine("how many the cost of the product?");
                            num = Convert.ToInt32(Console.ReadLine());
                            prod.Price = num;
                            Console.WriteLine("what is the name of the product?");
                            name = System.Console.ReadLine();
                            prod.Name = name;
                            try
                            {
                                dalProduct.Update(prod);
                            }
                            catch
                            {
                                Console.WriteLine("the product doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        default:
                            break;
                    };
                    break;
                case 2:
                    Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                    Console.WriteLine("-Choose 1 to Add a new Order to an existing set.");
                    Console.WriteLine("-Choose 2 to show any Order.");
                    Console.WriteLine("-Choose 3 to show the whole list of the Orders.");
                    Console.WriteLine("-Choose 4 to show details of any Order.");
                    Console.WriteLine("-Choose 5 to delete ant Order.");
                    Console.WriteLine("-Choose 6 to update ant Order.");
                    Console.WriteLine("-Choose another number to return to the menu");
                    choice = Convert.ToInt32(Console.ReadLine());
                    DO.Order ord = new Order();
                    switch (choice)
                    {
                        case 1:
                            dalOrder.Add(ord);
                            break;
                        case 2:
                            Console.WriteLine("enter the ID of the order you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                order = dalOrder.Get(num);
                                Console.WriteLine(order.ToString());
                            }
                            catch
                            {
                                Console.WriteLine("the order doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        case 3:
                            dalOrder.GetAll();
                            foreach (Order or in orders)
                            {
                                Console.WriteLine(or.ToString());
                            }
                            break;
                        case 4:
                            Console.WriteLine("enter the ID of the order you want to see his detalies");
                            num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                details = dalOrder.GetDetails(num);
                            }
                            catch
                            {
                                Console.WriteLine("the order doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            foreach (string str in details)
                            {
                                Console.WriteLine(str);
                            }
                            break;
                        case 5:
                            Console.WriteLine("enter the ID of the order you want do delete ");
                            num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                dalOrder.Delete(num);
                            }
                            catch
                            {
                                Console.WriteLine("the order doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        case 6:
                            Console.WriteLine("enter Id of the order you want to update");
                            num = System.Console.Read();
                            ord.ID = num;
                            Console.WriteLine("what is the name of the custumer?");
                            name = System.Console.ReadLine();
                            ord.CostumerName = name;
                            Console.WriteLine("what is the email of the custumer?");
                            email = System.Console.ReadLine();
                            ord.CostumerEmail = email;
                            Console.WriteLine("what is the address of the custumer?");
                            address = System.Console.ReadLine();
                            ord.CostumerAddress = address;
                            Console.WriteLine("what is the date of the order?");
                            date = Convert.ToDateTime(Console.ReadLine());
                            ord.OrderDate = date;
                            Console.WriteLine("what is the date of the ship?");
                            date = Convert.ToDateTime(Console.ReadLine());
                            ord.ShipDate = date;
                            Console.WriteLine("what is the date of the delivery?");
                            date = Convert.ToDateTime(Console.ReadLine());
                            ord.DeliveryDate = date;
                            try
                            {
                                dalOrder.Update(ord);
                            }
                            catch
                            {
                                Console.WriteLine("the order doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        default:
                            break;
                    };
                    break;

                case 3:
                    Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                    Console.WriteLine("-Choose 1 to Add a new OrderItem to an existing set.");
                    Console.WriteLine("-Choose 2 to show any OrderItem.");
                    Console.WriteLine("-Choose 3 to show all the OrderItems.");
                    Console.WriteLine("-Choose 4 to show details of any OrderItem by Product ID and Order ID.");
                    Console.WriteLine("-Choose 5 to delete ant OrderItem.");
                    Console.WriteLine("-Choose 6 to update ant OrderItem.");
                    Console.WriteLine("-Choose another number to return to the menu");
                    choice = Convert.ToInt32(Console.ReadLine());
                    DO.OrderItem oi = new OrderItem();
                    switch (choice)
                    {
                        case 1:
                            dalOrderItem.Add(oi);
                            break;
                        case 2:
                            Console.WriteLine("enter the ID of the order item you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                orderitem = dalOrderItem.Get(num);
                                Console.WriteLine(orderitem.ToString());
                            }
                            catch
                            {
                                Console.WriteLine("the order item doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        case 3:
                            dalOrderItem.GetAll();
                     foreach(OrderItem item in items)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 4:
                            Console.WriteLine("enter the ID of the order");
                            num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter the ID of the product");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                orderitem = dalOrderItem.GetOrderItem(num2, num);
                                Console.WriteLine(orderitem.ToString());
                            }
                            catch
                            {
                                Console.WriteLine("the order item doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        case 5:
                            Console.WriteLine("enter the ID of the order item you want do delete ");
                            num = System.Console.Read();
                            try
                            {
                                dalOrderItem.Delete(num);
                            }
                            catch
                            {
                                Console.WriteLine("the order item doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        case 6:
                            Console.WriteLine("enter Id of the order item you want to update");
                            num = System.Console.Read();
                            oi.id = num;
                            Console.WriteLine("enter Id of the order");
                            num = System.Console.Read();
                            oi.OrderID = num;
                            Console.WriteLine("enter Id of the product");
                            num = System.Console.Read();
                            oi.ProductID = num;
                            Console.WriteLine("hou many there is?");
                            num = System.Console.Read();
                            oi.Amount = num;
                            Console.WriteLine("how many the cost of the product?");
                            num = System.Console.Read();
                            oi.Price = num;
                            try
                            {
                                dalOrderItem.Update(oi);
                            }
                            catch
                            {
                                Console.WriteLine("the order item doesn't exist");
                            }
                            finally
                            {
                                Console.WriteLine("try again with correct number");
                            }
                            break;
                        default:
                            break;
                    };
                    break;
            };
        }
    }
};