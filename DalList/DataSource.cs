

using DO;
using System;


namespace Dal;

static internal class DataSource
{
    static readonly Random rand = new Random();
    internal static Product[] producrArr = new Product[50];
    internal static Order[] orderArr = new Order[100];
    internal static OrderItem[] orderItemArr = new OrderItem[200];

   
    private static Product AddProduct()
    {
        List<string> namesOfProducts = new List<string> { "Sofa", "Table", "Chair", "Wardrobe", "Dresser", "Bed", "Shelf", "Armchair" };//to initialize the names of the products
        Product product = new Product();
        product.ID = rand.Next(100, 999);
        product.Name = namesOfProducts[rand.Next(0,7)];
        product.Furniture = (DO.Furniture)rand.Next(0, 4);
        product.InStock=rand.Next(0, 100);
        product.Price = rand.Next(30, 300);
        return product;
    }

    private static Order AddOrder()
    {
        List<string> namesOfCustomers = new List<string> { "Avraam", "Itzchak", "Iakov", "Moshe", "Aharon", "Yosef", "David", "Shlomo",
                        "Yisroel", "Reuven", "Shimon", "Levi", "Yehuda", "Yissachar", "Zevulun", "Dan", "Naftali", "Gad", "Asher","Menashe", "Efraim", "Beniamin"};//to initialize the first customers names
        List<string> emailsOfCustomers = new List<string> { "Avraam@gmail.com", "Itzchak@gmail.com", "Iakov@gmail.com", "Moshe@gmail.com", "Aharon@gmail.com", "Yosef@gmail.com", "David@gmail.com", "Shlomo@gmail.com",
                        "Yisroel@gmail.com", "Reuven@gmail.com", "Shimon@gmail.com", "Levi@gmail.com", "Yehuda@gmail.com", "Yissachar@gmail.com", "Zevulun@gmail.com", "Dan@gmail.com", "Naftali@gmail.com", "Gad@gmail.com", "Asher@gmail.com","Menashe@gmail.com", "Efraim@gmail.com", "Beniamin@gmail.com"};//to initialize the customers emails
        List<string> addressOfCustumer = new List<string> { "Ben Yehuda, Jerusalem", "Jaffa, Jerusalem", "King Gorge, Jerusalem", "Dizingof, Tel Aviv", "Bialik, Tel Aviv", "Rabbi Akiva, Bnei Brak", "Hazon Ish, Bnei Brak", "Bnei Brit, Ashdod", "Yerushalaim, Zefat" };//to initialize the customers addresses
        Order order = new Order();
        order.ID = rand.Next(100, 999);
        order.CostumerName = namesOfCustomers[rand.Next(0, 21)];
        order.CostumerEmail= emailsOfCustomers[rand.Next(0, 21)];
        order.CostumerAddress=addressOfCustumer[rand.Next(0, 8)];
        order.OrderDate = DateTime.MinValue;
        order.ShipDate= DateTime.Now;
        order.DeliveryDate = DateTime.MaxValue;
        return order;
    }

    private static OrderItem AddOrderItem()
    {
        OrderItem orderItem = new OrderItem();
        orderItem.OrderID = rand.Next(100, 999);
        orderItem.ProductID=rand.Next(100, 999);
        return orderItem;
    }
    private static void Initialize()
    {
        for(int i = 0; i < 50; i++)
        {
            producrArr[i] = AddProduct();
        }
        for(int i = 0; i < 100; i++)
        {
            orderArr[i] = AddOrder();
        }
        for(int i = 0; i < 200; i++)
        {
            orderItemArr[i] = AddOrderItem();
        }

        
                }
            
    }
