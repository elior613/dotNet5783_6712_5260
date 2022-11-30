﻿

using DO;
using System;


namespace Dal;

internal sealed class DataSource
{
    private static DataSource _instance = null;
    public static DataSource Instance { get { return _instance; } }


    static readonly Random rand = new Random();
    internal Product[] producrArr = new Product[50];
    internal Order[] orderArr = new Order[100];
    internal OrderItem[] orderItemArr = new OrderItem[200];

    static DataSource()
    {
        _instance = new DataSource();
    }
    private DataSource()
    {
        s_Initialize();
    }

    private Product AddProduct(int countProduct)
    {
        List<string> namesOfProducts = new List<string> { "Sofa", "Table", "Chair", "Wardrobe", "Dresser", "Bed", "Shelf", "Armchair" };//to initialize the names of the products
        Product product = new Product();
        product.ID = countProduct++;
        product.Name = namesOfProducts[rand.Next(0, 7)];
        product.Furniture = (DO.Furniture)rand.Next(0, 4);
        product.InStock = rand.Next(0, 100);
        product.Price = rand.Next(30, 300);
        return product;
    }

    private Order AddOrder()
    {
        List<string> namesOfCustomers = new List<string> { "Avraam", "Itzchak", "Iakov", "Moshe", "Aharon", "Yosef", "David", "Shlomo",
                        "Yisroel", "Reuven", "Shimon", "Levi", "Yehuda", "Yissachar", "Zevulun", "Dan", "Naftali", "Gad", "Asher","Menashe", "Efraim", "Beniamin"};//to initialize the first customers names
        List<string> emailsOfCustomers = new List<string> { "Avraam@gmail.com", "Itzchak@gmail.com", "Iakov@gmail.com", "Moshe@gmail.com", "Aharon@gmail.com", "Yosef@gmail.com", "David@gmail.com", "Shlomo@gmail.com",
                        "Yisroel@gmail.com", "Reuven@gmail.com", "Shimon@gmail.com", "Levi@gmail.com", "Yehuda@gmail.com", "Yissachar@gmail.com", "Zevulun@gmail.com", "Dan@gmail.com", "Naftali@gmail.com", "Gad@gmail.com", "Asher@gmail.com","Menashe@gmail.com", "Efraim@gmail.com", "Beniamin@gmail.com"};//to initialize the customers emails
        List<string> addressOfCustumer = new List<string> { "Ben Yehuda, Jerusalem", "Jaffa, Jerusalem", "King Gorge, Jerusalem", "Dizingof, Tel Aviv", "Bialik, Tel Aviv", "Rabbi Akiva, Bnei Brak", "Hazon Ish, Bnei Brak", "Bnei Brit, Ashdod", "Yerushalaim, Zefat" };//to initialize the customers addresses
        Order order = new Order();
         DateTime date1 = new DateTime(2022, rand.Next(1, 12), rand.Next(1, 31));
        TimeSpan t = new TimeSpan(1, 5, 9, 6, 3);
        DateTime date2 = date1.Add(t);
        DateTime date3 = date2.Add(t);
        order.ID= Config.orderId;
        order.CostumerName = namesOfCustomers[rand.Next(0, 21)];
            order.CostumerEmail = emailsOfCustomers[rand.Next(0, 21)];
            order.CostumerAddress = addressOfCustumer[rand.Next(0, 8)];
            order.OrderDate = date1;
            order.ShipDate = date2;
            order.DeliveryDate = date3;
        return order;
    }

    private OrderItem AddOrderItem()
    {
        OrderItem orderItem = new OrderItem();
        orderItem.id = Config.orderItemId;
        orderItem.OrderID = Config.orderId;
        orderItem.ProductID = rand.Next(100000, 100200);
        return orderItem;
    }


    private void s_Initialize()
    {
        int countProduct = 100000;
        for (int i = 0; i < 50; i++)
        {
            producrArr[i] = AddProduct(countProduct);
            countProduct++;
        }

        for (int i = 0; i < 3; i++)
        {
            orderArr[i] = AddOrder();
            if (i > 50)
                orderArr[i].DeliveryDate = DateTime.MinValue;
            if(i>80)
                orderArr[i].ShipDate= DateTime.MinValue;    
        }

        for (int i = 0; i < 200; i++)
            orderItemArr[i] = AddOrderItem();

    }


    internal static class Config
    {

        internal static int productNum = 0;
        internal static int orderNum = 0;
        internal static int orderItemNum = 0;
        internal static int orderId = 1;
        public static int OrderId { get; }
        internal static int orderItemId = 1;
        public static int OrderItemId { get; }


    }
}