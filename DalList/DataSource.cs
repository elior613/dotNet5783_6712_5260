

using DO;
using System;
namespace Dal;



   



internal sealed class DataSource
{
    private static DataSource _instance = null;
    public static DataSource Instance { get { return _instance; } }

    //creating all the array we need for the each class
    static readonly Random rand = new Random();

    internal List<Product> producrArr = new List<Product>();
    internal List<Order> orderArr = new List<Order>();
    internal List<OrderItem> orderItemArr = new List<OrderItem>();


    static DataSource()
    {
        _instance = new DataSource();
    }
    private DataSource()
    {
        s_Initialize();
    }

    private void AddProduct(int countProduct)//adding products and fullfiling it's details
    {
        List<string> namesOfProducts = new List<string> { "Sofa", "Table", "Chair", "Wardrobe", "Dresser", "Bed", "Shelf", "Armchair" };//to initialize the names of the products
        Product product = new Product()
        {
            ID = countProduct++,
            Name = namesOfProducts[rand.Next(0, 7)],
            Furniture = (DO.Furniture)rand.Next(0, 4),
            InStock = rand.Next(0, 100),
            Price = rand.Next(30, 300)
        };
        producrArr.Add(product);//returning the new created product
    }

    private void AddOrder()//adding a new order 
    {
        List<string> namesOfCustomers = new List<string> { "Avraam", "Itzchak", "Iakov", "Moshe", "Aharon", "Yosef", "David", "Shlomo",
                        "Yisroel", "Reuven", "Shimon", "Levi", "Yehuda", "Yissachar", "Zevulun", "Dan", "Naftali", "Gad", "Asher","Menashe", "Efraim", "Beniamin"};//to initialize the first customers names
        List<string> emailsOfCustomers = new List<string> { "Avraam@gmail.com", "Itzchak@gmail.com", "Iakov@gmail.com", "Moshe@gmail.com", "Aharon@gmail.com", "Yosef@gmail.com", "David@gmail.com", "Shlomo@gmail.com",
                        "Yisroel@gmail.com", "Reuven@gmail.com", "Shimon@gmail.com", "Levi@gmail.com", "Yehuda@gmail.com", "Yissachar@gmail.com", "Zevulun@gmail.com", "Dan@gmail.com", "Naftali@gmail.com", "Gad@gmail.com", "Asher@gmail.com","Menashe@gmail.com", "Efraim@gmail.com", "Beniamin@gmail.com"};//to initialize the customers emails
        List<string> addressOfCustumer = new List<string> { "Ben Yehuda, Jerusalem", "Jaffa, Jerusalem", "King Gorge, Jerusalem", "Dizingof, Tel Aviv", "Bialik, Tel Aviv", "Rabbi Akiva, Bnei Brak", "Hazon Ish, Bnei Brak", "Bnei Brit, Ashdod", "Yerushalaim, Zefat" };//to initialize the customers addresses
 
         DateTime date1 = DateTime.Now;
        TimeSpan t = new TimeSpan(1, 5, 9, 6, 3);
        DateTime date2 = date1-t;
        DateTime date3 = date2-t;

        Order order = new Order()//initialising and completing it's deteails
        {
            ID = Config.OrderId,
            CostumerName = namesOfCustomers[rand.Next(0, 21)],
            CostumerEmail = emailsOfCustomers[rand.Next(0, 21)],
            CostumerAddress = addressOfCustumer[rand.Next(0, 8)],
            OrderDate = date3,
            ShipDate = date2
        };
        if (order.ID > 80)
            order.ShipDate = DateTime.MinValue;
            order.DeliveryDate = date1;
        if(order.ID > 50)
            order.DeliveryDate = DateTime.MinValue; 
        orderArr.Add(order);
    }

    private  void AddOrderItem()
    {
        OrderItem orderItem = new OrderItem()
        {
            ID = Config.OrderItemId,
            OrderID = rand.Next(1, 100),
            ProductID = rand.Next(100000, 100200),
            Amount = rand.Next(0, 100),
            Price = rand.Next(30, 300)
        };
        orderItemArr.Add(orderItem);
    }


    private void s_Initialize()//rules using for the initialing by creating some array for each class created
    {
        //creating list for the customers containing all their details
      
        int countProduct = 100000;
        for (int i = 0; i < 50; i++)
        {
            AddProduct(countProduct);
            countProduct++;
        }

        for (int i = 0; i < 100; i++)
        {
            AddOrder();
        }

        for (int i = 0; i < 200; i++)
             AddOrderItem();

    }


    internal static class Config
    {

        internal static int productNum = 0;
        internal static int orderNum = 0;
        internal static int orderItemNum = 0;
        internal static int orderId = 0;
        public static int OrderId //generating the ID for each new order 
        { 
            get => ++orderId;  
        }
        internal static int orderItemId = 0;
        public static int OrderItemId { get => ++orderItemId; }


    }
}