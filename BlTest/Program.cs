
using BlApi;
using BlImplementation;
using DalApi;
using DO;
using BO;
using Dal;
using static BO.Exceptions;
using System.Security.Principal;
using System.Collections.Generic;

namespace BlTest
{
    internal class Program
    {

        static IBL bl = new BL();
        static IDal dal = new DalList();


        static Random rand = new Random();
        static BO.Cart cart = new BO.Cart(); /*{
            CostumerName = "Moshe",
            CostumerEmail = "Moshe@gmail.com",
            CostumerAddress = "Ben Yehuda 5, Jerusalem",
            Items = null
        };*/
        static BO.Product product = new BO.Product();
        static BO.ProductItem productItem=new BO.ProductItem();
        static BO.Order order = new BO.Order();
        static BO.OrderTracking orderTracking = new BO.OrderTracking();
        static List<DO.Product> list=new List<DO.Product>();
        static List<BO.OrderItem> orderItems = new List<BO.OrderItem>();
        
      
       

        static void Main(string[] args)
        {
            int choice = 1;
            while (choice != 0)//enter in the main menu in which are the submenus for Product,Order and order Item.
            {

                //main menu
                Console.WriteLine("Which entity do you want ?");
                Console.WriteLine("1-Product");
                Console.WriteLine("2-Order");
                Console.WriteLine("3-Cart");
                Console.WriteLine("0-to end the program");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //Product Submenu
                        Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                        Console.WriteLine("-Choose 1 to get a list of the products.");
                        Console.WriteLine("-Choose 2 to get a list of catalog of the products");
                        Console.WriteLine("-Choose 3 to get a specific product depending of the ID (only for the admins)");
                        Console.WriteLine("-Choose 4 to get a specific product depending of the ID (for customers)");
                        Console.WriteLine("-Choose 5 to add any product");
                        Console.WriteLine("-Choose 6 to delete any product");
                        Console.WriteLine("-Choose 7 to update any product");
                        Console.WriteLine("-Choose another number to return to the menu");
                        choice = Convert.ToInt32(Console.ReadLine());//receive the choice of the user
                        int num,category;
                        
                        string name, email, address;                        

                        switch (choice)
                        {

                            case 1://get a list of the product
                                foreach (ProductForList pfl in bl.Product.GetProductForLists())
                                {
                                    Console.WriteLine(pfl);
                                }
                                break;

                            case 2://get a list of catalog of the products
                                order = bl.Order.Get(1);
                                orderItems.Add(order.Item);
                                cart.Items = orderItems;
                                foreach (ProductItem pi in bl.Product.GetProductCatalog(cart))
                                {
                                    Console.WriteLine(pi);
                                } 
                                break;
                            case 3://get a specific product depending of the ID (only for the admins)

                                Console.WriteLine("enter the id of the product you want");
                                num = Convert.ToInt32(Console.ReadLine());
                                try//if the id not correct ...
                                {
                                    product = bl.Product.Get(num);
                                    Console.WriteLine(product);
                                }
                                catch (ErrorDetailsException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                catch (DoesntExistException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 4://get a specific product depending of the ID (for customers)
                            
                                try//if the id not correct ...
                                {
                                    Console.WriteLine("enter the id of the product you want");
                                    num = Convert.ToInt32(Console.ReadLine());
                                    order = bl.Order.Get(1);
                                    orderItems.Add(order.Item);
                                    cart.Items = orderItems;
                                    productItem = bl.Product.Get(num, cart);
                                    Console.WriteLine(productItem);
                                }
                                catch (ErrorDetailsException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 5:// to add any product
                                try
                                {
                                    IEnumerable< ProductForList> list=bl.Product.GetProductForLists();
                                    list.ToList();
                                    product.ID = 100000 + list.Count();
                                    bl.Product.Add(product);
                                }
                                catch
                                {

                                    product.ID++;
                                    product.Furniture = (BO.Furniture)rand.Next(0, 4);
                                    bl.Product.Add(product);
                                }
                                
                                break;
                            case 6://to delete any product
                                Console.WriteLine("enter the id of the product you want to delete");
                                num= Convert.ToInt32(Console.ReadLine());
                                try //if the product is available on order
                                {
                                    bl.Product.Delete(num);
                                }
                                catch (AvailableException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                        
                                break;
                            case 7://to update any product

                                try//if the the parameters not correct ...
                                {
                                    Console.WriteLine("enter Id of the product you want to update");
                                    num = Convert.ToInt32(Console.ReadLine());
                                    product.ID = num;//receiving the ID of the product we want to modyfie
                                    Console.WriteLine("which category you want to update?");
                                    Console.WriteLine("for living Room furniture enter 1");
                                    Console.WriteLine("for bed room furniture enter 2");
                                    Console.WriteLine("for kitchen furniture enter 3");
                                    Console.WriteLine("for toilets enter 4");
                                    Console.WriteLine("for office furniture enter 5");
                                    category = Convert.ToInt32(Console.ReadLine());
                                    if (category == 1)
                                        product.Furniture = BO.Furniture.livingRoomFurniture;
                                    else if (category == 2)
                                        product.Furniture = BO.Furniture.bedroomFurniture;
                                    else if (category == 3)
                                        product.Furniture = BO.Furniture.kitchenFurniture;
                                    else if (category == 4)
                                        product.Furniture = BO.Furniture.toilets;
                                    else if (category == 5)
                                        product.Furniture = BO.Furniture.officeFurniture;
                                    else
                                        Console.WriteLine("wrong choice. Enter a valid number.");
                                    Console.WriteLine("hou many there is in stock?");
                                    num = Convert.ToInt32(Console.ReadLine());
                                    product.InStock = num;//modyfing the stock...
                                    Console.WriteLine("how many the cost of the product?");
                                    num = Convert.ToInt32(Console.ReadLine());
                                    product.Price = num;//...the price...
                                    Console.WriteLine("what is the name of the product?");
                                    name = System.Console.ReadLine();//...the name
                                    product.Name = name;
                                    bl.Product.Update(product);
                                }
                                catch (ErrorDetailsException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                
                                break;
                            default:
                                break;
                        };
                        break;
                    case 2:
                        //Order Submenu
                        Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                        Console.WriteLine("-Choose 1 to get a list of the orders.");
                        Console.WriteLine("-Choose 2 to get an order by id");
                        Console.WriteLine("-Choose 3 to update order shipping");
                        Console.WriteLine("-Choose 4 to to update order delivering");
                        Console.WriteLine("-Choose 5 to track the order");
                        Console.WriteLine("-Choose another number to return to the menu");
                        choice = Convert.ToInt32(Console.ReadLine());//receive the choice of the user


                        switch (choice)
                        {

                            case 1://get a list of the orders
                                foreach ( OrderForList ofl in bl.Order.GetOrders())
                                {
                                    Console.WriteLine(ofl);
                                }
                                break;

                            case 2://get an order by ID

                                Console.WriteLine("enter the id of the order you want");
                                num = Convert.ToInt32(Console.ReadLine());
                                try//if the id not correct ...
                                {
                                    order = bl.Order.Get(num);
                                    Console.WriteLine(order);
                                }
                                catch (ErrorDetailsException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 3://update order shipping
                                Console.WriteLine("enter the id of the order you want");
                                num = Convert.ToInt32(Console.ReadLine());
                                try//if the id not correct ...
                                {
                                    order = bl.Order.Update(num);
                                    Console.WriteLine(order);
                                }
                                catch (ErrorDetailsException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 4://update order delivering
                                Console.WriteLine("enter the id of the order you want");
                                num = Convert.ToInt32(Console.ReadLine());
                                try//if the id not correct ...
                                {
                                    order = bl.Order.updateDelivery(num);
                                    Console.WriteLine(order);
                                }
                                catch (ErrorDetailsException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                break;
                            case 5:// to track the order
                                Console.WriteLine("enter the id of the order you want");
                                num = Convert.ToInt32(Console.ReadLine());
                                try//if the id not correct ...
                                {
                                    orderTracking = bl.Order.Tracking(num);
                                    Console.WriteLine(orderTracking);
                                }
                                catch (DoesnotExistException ex)//...say it to the user...
                                {
                                    Console.WriteLine(ex);
                                }
                                break;
                            default:
                                break;
                        };
                        break;

                    case 3:

                        //Cart Submenu
                        Console.WriteLine("Choose 1 to Add Product To Cart");
                        Console.WriteLine("Choose 2 to Update Amount Product");
                        Console.WriteLine("Choose 3 to Confirm Order");
                        Console.WriteLine("Choose another number to return to the menu");
                        choice = Convert.ToInt32(Console.ReadLine());//receive the choice of the user
                        BO.Cart tempCart;
                        int id, amount;
                        switch (choice)
                        {
                            case 1:
                                try//if the id correct and there is in stock
                                {
                                    Console.WriteLine(@"Enter the product ID number that you want to add");
                                    while (!int.TryParse(Console.ReadLine(), out id)) ;
                                    tempCart = bl.Cart.Add(cart, id);

                                    foreach (BO.OrderItem oItem in cart.Items)
                                    {
                                        Console.WriteLine(oItem);
                                    }
                                
                                }
                                catch(DoesnotExistException ex)
                                {
                                    Console.WriteLine(ex);
                                }
                                catch (NotEnoughInStock ex)
                                {
                                    Console.WriteLine(ex);
                                }
                                break;


                            case 2:
                                try
                                {
                                    Console.WriteLine("enter the id of the product you want to update");
                                    while (!int.TryParse(Console.ReadLine(), out id)) ;
                                    Console.WriteLine("how many product do you want to update");
                                    while (!int.TryParse(Console.ReadLine(), out amount)) ;
                                    bl.Cart.Update(cart, id, amount);
                                    if (cart.Items != null)
                                    {
                                        foreach (BO.OrderItem oItem in cart.Items)
                                            Console.WriteLine(oItem);
                                    }
                                    else
                                        Console.WriteLine("the product doesn't exist in cart");
                                }
                                catch (DoesnotExistException ex)
                                {
                                    Console.WriteLine(ex);
                                } 
                                break;

                            case 3:
                                string? name1, mail1, address1;
                                Console.WriteLine("Name: ");
                                name1 = Console.ReadLine();
                                Console.WriteLine("eMail: ");
                                mail1 = Console.ReadLine();
                                Console.WriteLine("Adress: ");
                                address1 = Console.ReadLine();
                                try
                                {
                                    bl.Cart.Confirmation(cart, name1, mail1, address1);
                                }
                                catch(DoesnotExistException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (NotEnoughInStock ex)
                                {
                                    Console.WriteLine(ex);
                                }
                                break;

                            default:
                                break;
                        }




                        break;

                };
            }
        }
       
    }
   
}

