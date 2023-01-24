
using BlApi;
using BlImplementation;
using DalApi;
using DO;
using BO;
using Dal;
using static BO.Exceptions;

namespace BlTest
{
    internal class Program
    {

        static IBL bl = new BL();
        static IDal dal = new DalList();
        static BL bl2 = new BL();

        static Random rand = new Random();
        static BO.Cart cart = new BO.Cart() {
            CostumerName = "Moshe",
            CostumerEmail = "Moshe@gmail.com",
            CostumerAddress = "Ben Yehuda 5, Jerusalem",
            Items = null
        };
        static BO.Product product = new BO.Product();
        static BO.ProductItem productItem=new BO.ProductItem();
       

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
                                foreach (ProductForList pfl in bl.Product.GetProductForLists(null))
                                {
                                    Console.WriteLine(pfl);
                                }
                                break;

                            case 2://get a list of catalog of the products

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
                                break;
                            case 4://get a specific product depending of the ID (for customers)
                            
                                try//if the id not correct ...
                                {
                                    Console.WriteLine("enter the id of the product you want");
                                    num = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("enter your name");
                                    name = System.Console.ReadLine();
                                    cart.CostumerName = name;
                                    Console.WriteLine("enter your email");
                                    email = System.Console.ReadLine();
                                    cart.CostumerEmail = email;
                                    Console.WriteLine("enter your adderss");
                                    address = System.Console.ReadLine();
                                    cart.CostumerAddress = address;
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
                                catch (Exception ex)//...say it to the user...
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

                };
            }
        }
       
    }
   
}

