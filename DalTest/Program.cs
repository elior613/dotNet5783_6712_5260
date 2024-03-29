﻿// See https://aka.ms/new-console-template for more information

using Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
#nullable disable

class DalTest
{
    static DalApi.IDal? dal = DalApi.Factory.Get();

    static void Main(string[] args)
    {//initialising of all the class that we will need in our program

        Random rand = new Random();
        IEnumerable<Product?>products;
        IEnumerable<Order?>orders;
        IEnumerable<OrderItem?>items;
        IEnumerable<string> details=new List<string>();
        Product product = new Product()
        {
            ID = 100050,
            Furniture = (DO.Furniture)rand.Next(0, 4)
        };

        Order order = new Order();
  
        OrderItem orderitem = new OrderItem();
       

        int choice = 1;
        while (choice != 0)//enter in the main menu in which are the submenus for Product,Order and order Item.
        {

            //main menu
            Console.WriteLine("Which entity do you want ?");
            Console.WriteLine("1-Product");
            Console.WriteLine("2-Order");
            Console.WriteLine("3-OrderItem");
            Console.WriteLine("0-to end the program");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    //Product Submenu
                    Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                    Console.WriteLine("-Choose 1 to add a new product.");
                    Console.WriteLine("-Choose 2 to get any product");
                    Console.WriteLine("-Choose 3 to show all products.");
                    Console.WriteLine("-Choose 4 to delete any product");
                    Console.WriteLine("-Choose 5 to update any product");
                    Console.WriteLine("-Choose 6 to get any product");
                    Console.WriteLine("-Choose another number to return to the menu");
                    choice = Convert.ToInt32(Console.ReadLine());//receive the choice of the user
                    int num, num2, category;//those variable will receive the ID off the product we want to see or the ID of the product we want to update
                    //DO.Product prod = new DO.Product();
                    string  name, email, address;
                    DateTime date;
                    switch (choice)
                    {

                        case 1://adding a new product
                            try
                            {
                              
                                dal.Product.Add(product);
                            }
                            catch
                            {

                                    product.ID++;
                                    product.Furniture = (DO.Furniture)rand.Next(0, 4);
                                dal.Product.Add(product);
                            }
                            break;

                        case 2://looking for the details of an existing product
                            Console.WriteLine("enter the ID of the product you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the product doesn't exist ...
                            {
                                product = dal.Product.Get(num);
                                Console.WriteLine(product);
                            }
                            catch(DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        case 3://show all the details of all the existing products
                            try//if the product doesn't exist ...
                            {
                                products = dal.Product.GetAll(null);
                                foreach (Product p in products)
                                {
                                    Console.WriteLine(p);
                                }
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }
                            
                            break;
                        case 4://for deleting a Product
                            Console.WriteLine("enter the ID of the product you want do delete ");
                            num = Convert.ToInt32(Console.ReadLine());//asking the ID of the product we want to delete
                            try //if we are trying to delete a product that doesn't exist
                            {
                                dal.Product.Delete(num);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            break;
                        case 5://updating a product

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
                                product.Furniture = DO.Furniture.livingRoomFurniture;
                            else if (category == 2)
                                product.Furniture = DO.Furniture.bedroomFurniture;
                            else if (category == 3)
                                product.Furniture = DO.Furniture.kitchenFurniture;
                            else if (category == 4)
                                product.Furniture = DO.Furniture.toilets;
                            else if (category == 5)
                                product.Furniture = DO.Furniture.officeFurniture;
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
                            try
                            {
                                dal.Product.Update(product);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }
                            break;

                        case 6:
                            Console.WriteLine("enter the ID of the product you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the product doesn't exist ...
                            {
                                Product? productN=new Product?();
                                productN = dal.Product.Get(item => item?.ID == num);
                                Console.WriteLine(productN);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            break;
                        default:
                            break;
                    };
                    break;
                case 2://Order Submenue
                    Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                    Console.WriteLine("-Choose 1 to Add a new Order to an existing set.");
                    Console.WriteLine("-Choose 2 to show any Order.");
                    Console.WriteLine("-Choose 3 to show the whole list of the Orders.");
                    Console.WriteLine("-Choose 4 to show details of any Order.");
                    Console.WriteLine("-Choose 5 to delete ant Order.");
                    Console.WriteLine("-Choose 6 to update ant Order.");
                    Console.WriteLine("-Choose 7 to get any order");
                    Console.WriteLine("-Choose another number to return to the menu");
                    choice = Convert.ToInt32(Console.ReadLine());
                    //DO.Order ord = new Order();
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                int id = dal.Order.Add(order);//adding a new order
                                //to update a new order in the order item table
                                OrderItem ordItem = new OrderItem();
                                ordItem.OrderID = id;
                                try
                                {
                                    dal.OrderItem.Add(ordItem);
                                }
                                      
                            catch
                            {
                                items = dal.OrderItem.GetAll();//adding a new ID for the new Order
                                orderitem = (DO.OrderItem)items.ToList()[items.Count() - 1];
                                ordItem.ID++;
                                dal.OrderItem.Add(ordItem);//adding a new order
                            }
                            }
                            catch
                            {

                                orders=dal.Order.GetAll();//adding a new ID for the new Order
                                order = (DO.Order)orders.ToList()[orders.Count()-1];
                                order.ID++;
                                dal.Order.Add(order);//adding a new order
                            }
                            break;
                        case 2://show an order depending of it's ID
                            Console.WriteLine("enter the ID of the order you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the Id doesn't match with any known order
                            {
                                order = dal.Order.Get(num);
                                Console.WriteLine(order);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        case 3:
                            try//if the product doesn't exist ...
                            {
                                orders = dal.Order.GetAll(null);
                                foreach (Order p in orders)
                                {
                                    Console.WriteLine(p);
                                }
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

           
                            break;


                        case 4://showing all the details of an order depending 
                            Console.WriteLine("enter the ID of the order you want to see his detalies");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the order doesn't exist
                            {
                                details = dal.Order.GetDetails(num);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            foreach (string str in details)
                            {
                                Console.WriteLine(str);
                            }
                            break;


                        case 5://for deleting orders depending of their ID
                            Console.WriteLine("enter the ID of the order you want do delete ");
                            num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                dal.Order.Delete(num);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            break;


                        case 6://updating the orders 
                            Console.WriteLine("enter Id of the order you want to update");
                            num = Convert.ToInt32(Console.ReadLine());
                            order.ID = num;//selecting the ID
                            Console.WriteLine("what is the name of the custumer?");
                            name = System.Console.ReadLine();
                            order.CostumerName = name;//updating name...
                            Console.WriteLine("what is the email of the custumer?");
                            email = System.Console.ReadLine();
                            order.CostumerEmail = email;//email...
                            Console.WriteLine("what is the address of the custumer?");
                            address = System.Console.ReadLine();
                            order.CostumerAddress = address;//adress...
                            Console.WriteLine("what is the date of the order?");
                            date = Convert.ToDateTime(Console.ReadLine());
                            order.OrderDate = date;// the date the order was placed...
                            Console.WriteLine("what is the date of the ship?");
                            date = Convert.ToDateTime(Console.ReadLine());
                            order.ShipDate = date;// the date the ship date was effective
                            Console.WriteLine("what is the date of the delivery?");
                            date = Convert.ToDateTime(Console.ReadLine());
                            order.DeliveryDate = date;//adjusting the delivery date 
                            try//checking if the order does exist or not
                            {
                                dal.Order.Update(order);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        case 7:
                            Console.WriteLine("enter the ID of the order you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the order doesn't exist ...
                            {
                                Order? OrderN = new Order?();
                                OrderN = dal.Order.Get(item => item?.ID == num);
                                Console.WriteLine(OrderN);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            break;
                        default:
                            break;
                    };
                    break;

                case 3://OrderItem menue
                    Console.WriteLine("Hello, welcome to the shop!! What to you want to do?");
                    Console.WriteLine("-Choose 1 to Add a new OrderItem to an existing set.");
                    Console.WriteLine("-Choose 2 to show any OrderItem.");
                    Console.WriteLine("-Choose 3 to show all the OrderItems.");
                   // Console.WriteLine("-Choose 4 to show details of any OrderItem by Product ID and Order ID.");
                    Console.WriteLine("-Choose 5 to delete ant OrderItem.");
                    Console.WriteLine("-Choose 6 to update ant OrderItem.");
                    Console.WriteLine("-Choose 7 to get any order item");
                    Console.WriteLine("-Choose another number to return to the menu");
                    choice = Convert.ToInt32(Console.ReadLine());
                    //DO.OrderItem oi = new OrderItem();
                    switch (choice)
                    {
                        case 1://adding a new order item
                            try {
                                dal.OrderItem.Add(orderitem);
                            }
                            catch
                            {
                                items = dal.OrderItem.GetAll();//adding a new ID for the new Order
                                orderitem = (DO.OrderItem)items.ToList()[items.Count() - 1];
                                orderitem.ID++;
                                dal.OrderItem.Add(orderitem);//adding a new order
                            }
                            break;

                        case 2://showing an orderitem depending of it's ID
                            Console.WriteLine("enter the ID of the order item you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the ID doen't existe
                            {
                                orderitem = dal.OrderItem.Get(num);
                                Console.WriteLine(orderitem);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            break;
                        case 3:
                            try//if the product doesn't exist ...
                            {
                                items = dal.OrderItem.GetAll(null);
                                foreach (OrderItem p in items)
                                {
                                    Console.WriteLine(p);
                                }
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }
                    
                            break;
                       /* case 4:
                            Console.WriteLine("enter the ID of the order");
                            num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter the ID of the product");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                orderitem = (DO.OrderItem)dal.OrderItem.GetOrderItem(num2, num);
                                Console.WriteLine(orderitem);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            break;
                       */

                        case 5://delete an order item depending of it's ID
                            Console.WriteLine("enter the ID of the order item you want do delete ");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the ID choosen already doesn't exist
                            {
                                dal.OrderItem.Delete(num);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }

                            break;


                        case 6://updatin an order item
                            Console.WriteLine("enter Id of the order item you want to update");
                            num = Convert.ToInt32(Console.ReadLine());
                            orderitem.ID = num;//choosing the ID of the order Item we want to update
                            Console.WriteLine("enter Id of the order");
                            num = Convert.ToInt32(Console.ReadLine());
                            orderitem.OrderID = num;//updating ID of the order
                            Console.WriteLine("enter Id of the product");
                            num = Convert.ToInt32(Console.ReadLine());
                            orderitem.ProductID = num;//updating the ID of the product
                            Console.WriteLine("hou many there is?");
                            num = Convert.ToInt32(Console.ReadLine());
                            orderitem.Amount = num;//updating the amount
                            Console.WriteLine("how many the cost of the product?");
                            num = Convert.ToInt32(Console.ReadLine());//updating the price
                            orderitem.Price = num;
                            try
                            {
                                dal.OrderItem.Update(orderitem);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        case 7:
                            Console.WriteLine("enter the ID of the order item you want to see");
                            num = Convert.ToInt32(Console.ReadLine());
                            try//if the order item  doesn't exist ...
                            {
                                OrderItem? OrderItemN = new OrderItem?();
                                OrderItemN = dal.OrderItem.Get(item => item?.ID == num);
                                Console.WriteLine(OrderItemN);
                            }
                            catch (DoesntExistException ex)//...say it to the user...
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
};