

using DO;
using System;
using System.Xml.Linq;

namespace Dal;

internal sealed class DataSource
{
    private static DataSource _instance = null;
    public static DataSource Instance { get { return _instance; } }

    //creating all the array we need for the each class
    static readonly Random rand = new Random();

    internal List<Product?> producrArr = new List<Product?>();
    internal List<Order?> orderArr = new List<Order?>();
    internal List<OrderItem?> orderItemArr = new List<OrderItem?>();

    //initializing the product name
    public string initializingName(Product product)
    {
        List<string> namesOfProducts = new List<string> { "Sofa", "Armchair", "Table", "Chair", "Closet", "Shelf", "Bed" };//to initialize the names of the products
        if (product.Furniture == DO.Furniture.livingRoomFurniture)
            product.Name = namesOfProducts[rand.Next(0, 5)];
        else if (product.Furniture == DO.Furniture.bedroomFurniture)
            product.Name = namesOfProducts[rand.Next(2, 6)];
        else if (product.Furniture == DO.Furniture.kitchenFurniture)
            product.Name = namesOfProducts[rand.Next(2, 5)];
        else if (product.Furniture == DO.Furniture.toilets)
            product.Name = namesOfProducts[rand.Next(4, 5)];
        else if (product.Furniture == DO.Furniture.officeFurniture)
            product.Name = namesOfProducts[rand.Next(2, 5)];
        return product.Name;
    }

    //counters of evere furniture, to count how many are in stock
    public  int livingRoomSofaCount = rand.Next(0, 300);
    public  int livingRoomTableCount = rand.Next(0, 300);
    public  int livingRoomChairCount = rand.Next(0, 300);
    public  int livingRoomClosetCount = rand.Next(0, 300);
    public  int livingRoomShelfCount = rand.Next(0, 300);
    public  int livingRoomArmchairCount = 0;
    public  int bedroomTableCount = rand.Next(0, 300);
    public  int bedroomChairCount = rand.Next(0, 300);
    public  int bedroomClosetCount = rand.Next(0, 300);
    public  int bedroomShelfCount = rand.Next(0, 300);
    public  int bedroomBedCount = rand.Next(0, 300);
    public  int kitchenTableCount = rand.Next(0, 300);
    public  int kitchenChairCount = rand.Next(0, 300);
    public  int kitchenClosetCount = rand.Next(0, 300);
    public  int kitchenShelfCount = 0;
    public  int toiletsClosetCount = rand.Next(0, 300);
    public  int toiletsShelfCount = rand.Next(0, 300);
    public  int officeTableCount = rand.Next(0, 300);
    public  int officeChairCount = rand.Next(0, 300);
    public  int officeClosetCount = rand.Next(0, 300);
    public  int officeShelfCount = 0;

    //initializing the number of the product in stock
    public int initializingInStock(Product product)
    {
        if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Sofa")
            product.InStock = livingRoomSofaCount;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Armchair")
            product.InStock = livingRoomArmchairCount;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Table")
            product.InStock = livingRoomTableCount;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Chair")
            product.InStock = livingRoomChairCount;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Closet")
            product.InStock = livingRoomClosetCount;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Shelf")
            product.InStock = livingRoomShelfCount;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Table")
            product.InStock = bedroomTableCount;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Chair")
            product.InStock = bedroomChairCount;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Closet")
            product.InStock = bedroomClosetCount;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Shelf")
            product.InStock = bedroomShelfCount;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Bed")
            product.InStock = bedroomBedCount;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Table")
            product.InStock = kitchenTableCount;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Chair")
            product.InStock = kitchenChairCount;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Closet")
            product.InStock = kitchenClosetCount;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Shelf")
            product.InStock = kitchenShelfCount;
        else if (product.Furniture == DO.Furniture.toilets && product.Name == "Closet")
            product.InStock = toiletsClosetCount;
        else if (product.Furniture == DO.Furniture.toilets && product.Name == "Shelf")
            product.InStock = toiletsShelfCount;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Table")
            product.InStock = officeTableCount;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Chair")
            product.InStock = officeChairCount;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Closet")
            product.InStock = officeClosetCount;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Shelf")
            product.InStock = officeShelfCount;

        return product.InStock;
    }


    //initializing the price of every product
    public double initializingPrice(Product product)
    {
        if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Sofa")
            product.Price = 1100;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Armchair")
            product.Price = 900;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Table")
            product.Price = 2000;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Chair")
            product.Price = 600;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Closet")
            product.Price = 4000;
        else if (product.Furniture == DO.Furniture.livingRoomFurniture && product.Name == "Shelf")
            product.Price = 200;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Table")
            product.Price = 500;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Chair")
            product.Price = 300;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Closet")
            product.Price = 3000;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Shelf")
            product.Price = 200;
        else if (product.Furniture == DO.Furniture.bedroomFurniture && product.Name == "Bed")
            product.Price = 1800;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Table")
            product.Price = 1750;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Chair")
            product.Price = 500;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Closet")
            product.Price = 2000;
        else if (product.Furniture == DO.Furniture.kitchenFurniture && product.Name == "Shelf")
            product.Price = 200;
        else if (product.Furniture == DO.Furniture.toilets && product.Name == "Closet")
            product.Price = 1500;
        else if (product.Furniture == DO.Furniture.toilets && product.Name == "Shelf")
            product.Price = 200;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Table")
            product.Price = 1650;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Chair")
            product.Price = 1000;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Closet")
            product.Price = 1050;
        else if (product.Furniture == DO.Furniture.officeFurniture && product.Name == "Shelf")
            product.Price = 200;

        return product.Price;
    }

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
        Product product = new Product()
        {
            ID = countProduct++,
            Furniture = (DO.Furniture)rand.Next(0, 5)
        };
        product.Name = initializingName(product);
        product.InStock = initializingInStock(product);
        product.Price = initializingPrice(product);     
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

    int countOrder = 0;
    private  void AddOrderItem()
    {
        OrderItem orderItem = new OrderItem()
        {
            ID = Config.OrderItemId,
            OrderID = ++countOrder,
            ProductID = rand.Next(100000, 100000 + producrArr.Count())
        };
        if (countOrder > 100)
            orderItem.OrderID = rand.Next(1, 100);
        foreach(Product product in producrArr)
        {
            if (product.ID == orderItem.ProductID)
            {
                orderItem.Price=product.Price;
                orderItem.Amount = product.InStock;
            }
        }
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