

using DO;
using System.Net;
using DalApi;
using System.Linq;

namespace Dal;

internal class DalOrder:IOrder
{
    DataSource dataSource = DataSource.Instance;
    static readonly Random rand = new Random();
    public  int Add(DO.Order ord)
    {
        for(int i = 0; i <dataSource.orderArr.Count; i++)
        {
            if (dataSource.orderArr[i]?.ID == ord.ID)
                throw new ExistException();
        }

        List<string> namesOfCustomers = new List<string> { "Avraam", "Itzchak", "Iakov", "Moshe", "Aharon", "Yosef", "David", "Shlomo",
                        "Yisroel", "Reuven", "Shimon", "Levi", "Yehuda", "Yissachar", "Zevulun", "Dan", "Naftali", "Gad", "Asher","Menashe", "Efraim", "Beniamin"};//to initialize the first customers names
        List<string> emailsOfCustomers = new List<string> { "Avraam@gmail.com", "Itzchak@gmail.com", "Iakov@gmail.com", "Moshe@gmail.com", "Aharon@gmail.com", "Yosef@gmail.com", "David@gmail.com", "Shlomo@gmail.com",
                        "Yisroel@gmail.com", "Reuven@gmail.com", "Shimon@gmail.com", "Levi@gmail.com", "Yehuda@gmail.com", "Yissachar@gmail.com", "Zevulun@gmail.com", "Dan@gmail.com", "Naftali@gmail.com", "Gad@gmail.com", "Asher@gmail.com","Menashe@gmail.com", "Efraim@gmail.com", "Beniamin@gmail.com"};//to initialize the customers emails
        List<string> addressOfCustumer = new List<string> { "Ben Yehuda, Jerusalem", "Jaffa, Jerusalem", "King Gorge, Jerusalem", "Dizingof, Tel Aviv", "Bialik, Tel Aviv", "Rabbi Akiva, Bnei Brak", "Hazon Ish, Bnei Brak", "Bnei Brit, Ashdod", "Yerushalaim, Zefat" };//to initialize the customers addresses
        
        DateTime date1 = DateTime.Now;
        TimeSpan t = new TimeSpan(1, 5, 9, 6, 3);
        DateTime date2 = date1 - t;
        DateTime date3 = date2 - t;

        ord.ID = DataSource.Config.OrderId;//adding a new ID for the new Order
        ord.CostumerName = namesOfCustomers[rand.Next(0, 21)];
        ord.CostumerEmail = emailsOfCustomers[rand.Next(0, 21)];
        ord.CostumerAddress = addressOfCustumer[rand.Next(0, 8)];
        ord.OrderDate = date3;
        ord.ShipDate = date2;
        ord.DeliveryDate = date1;
        dataSource.orderArr.Add(ord);//addingg the new order in the array with all the orders 
        DataSource.Config.productNum++;
        Console.WriteLine("The order has been successfully added");
        return ord.ID;
    }

    public  Order Get(int num)
    {
        DO.Order ord = new DO.Order();
        for (int i = 0; i < dataSource.orderArr.Count; i++)//get thanks to a loop in an array an order
        {
            if (dataSource.orderArr[i]?.ID == num)
            {
                ord = (DO.Order)dataSource.orderArr?[i];
                return ord;
            }
        }
        throw new DoesntExistException();//if the order doesn't exist
    }

    
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter = null) =>
        (filter == null ? dataSource.orderArr.Select(item => item) : dataSource.orderArr.Where(filter))
        ?? throw new DoesntExistException("Missing Order");
    public Order? Get(Func<Order?, bool>? function) // stage 3
    {
        foreach (var item in dataSource.orderArr)
            if (function(item))
                return item.Value;
        throw new DoesntExistException("Order doesn't exist");
        /*
        var v = from item in DataSource.orders // stage 5 
                where function(item)
                select item;
        return v.FirstOrDefault(); // return the order or null
        */
    }


    public IEnumerable<string?> GetDetails(int IDnum)//showing all the details about an order depending of it's ID
    {
        List<string> list = new List<string>();
        for(int i=0; i< dataSource.orderArr.Count; i++)
        {
            if (dataSource.orderArr[i]?.ID == IDnum)
            {
                list.Add(dataSource.orderArr[i]?.CostumerName);
                list.Add(dataSource.orderArr[i]?.CostumerEmail);
                list.Add(dataSource.orderArr[i]?.CostumerAddress);
                list.Add(dataSource.orderArr[i]?.OrderDate.ToString());
                list.Add(dataSource.orderArr[i]?.ShipDate.ToString());
                list.Add(dataSource.orderArr[i]?.DeliveryDate.ToString());
            }
        }
        if (list.Count > 0)
            return list;
        else
            throw new DoesntExistException();//sending a message if the order doesn't exist
    }
    public  void Delete(int num)//deleting an order in the array by remplacing his ID by 0
    {
        for(int i=0; i< dataSource.orderArr.Count; i++)
        {
            if (dataSource.orderArr[i]?.ID == num)
            {
                dataSource.orderArr.Remove(dataSource.orderArr[i]);
                Console.WriteLine("The order has been successfully deleted");
                return;
            }
        }
        throw new DoesntExistException();//if the order didn't exist
    }

    public  void Update(DO.Order? ord)//updating all the details about the order 
    {
        for (int i = 0; i < dataSource.orderArr.Count; i++)
        {
            if (dataSource.orderArr[i]?.ID == ord?.ID)
            {
                dataSource.orderArr[i]=ord;
                Console.WriteLine("The order has been updated successfully");
                return;
            }
        }
        throw new DoesntExistException();//if we were trying to update an inexisting order
        }
    }

