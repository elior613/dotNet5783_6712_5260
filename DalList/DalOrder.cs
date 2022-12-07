

using DO;
using System.Net;

namespace Dal;

public class DalOrder
{
    DataSource dataSource = DataSource.Instance;
    public  int Add(DO.Order ord)
    {
   
        ord.ID = DataSource.Config.orderId;
        dataSource.orderArr[DataSource.Config.productNum] = ord;
        DataSource.Config.productNum++;
        Console.WriteLine("The order has been successfully added");
        return ord.ID;
    }

    public  DO.Order Get(int num)
    {
        DO.Order ord = new DO.Order();
        for (int i = 0; i < dataSource.orderArr.Length; i++)
        {
            if (dataSource.orderArr[i].ID == num)
            {
                ord = dataSource.orderArr[i];
                return ord;
            }
        }
        throw new Exception("the order doesn't exist");
    }

    public  DO.Order[] GetAll()
    {
        DO.Order[] ord = new DO.Order[dataSource.orderArr.Length];
        for(int i=0; i<ord.Length; i++)
            ord[i] = dataSource.orderArr[i];
        return ord;
    }

    public  List<string> GetDetails(int IDnum)
    {
        List<string> list = new List<string>();
        for(int i=0; i< dataSource.orderArr.Length; i++)
        {
            if (dataSource.orderArr[i].ID == IDnum)
            {
                list.Add(dataSource.orderArr[i].CostumerName);
                list.Add(dataSource.orderArr[i].CostumerEmail);
                list.Add(dataSource.orderArr[i].CostumerAddress);
                list.Add(dataSource.orderArr[i].OrderDate.ToString());
                list.Add(dataSource.orderArr[i].ShipDate.ToString());
                list.Add(dataSource.orderArr[i].DeliveryDate.ToString());
            }
        }
        if (list.Count > 0)
            return list;
        else
            throw new Exception("the order doesn't exist");
    }
    public  void Delete(int num)
    {
        for(int i=0; i< dataSource.orderArr.Length; i++)
        {
            if (dataSource.producrArr[i].ID == num)
            {
                dataSource.producrArr[i].ID = 0;
                Console.WriteLine("The order has been successfully deleted");
                return;
            }
        }
        throw new Exception("the order doesn't exist");
    }

    public  void Update(DO.Order ord)
    {
        for (int i = 0; i < dataSource.orderArr.Length; i++)
        {
            if (dataSource.orderArr[i].ID == ord.ID)
            {
                dataSource.orderArr[i].OrderDate = ord.OrderDate;
                dataSource.orderArr[i].ShipDate = ord.ShipDate;
                dataSource.orderArr[i].DeliveryDate = ord.DeliveryDate;
                dataSource.orderArr[i].CostumerName = ord.CostumerName;
                dataSource.orderArr[i].CostumerEmail = ord.CostumerEmail;
                dataSource.orderArr[i].CostumerAddress = ord.CostumerAddress;
                Console.WriteLine("The order has been updated successfully");
                return;
            }
        }
                throw new Exception("the order doesn't exist");
        }
    }

