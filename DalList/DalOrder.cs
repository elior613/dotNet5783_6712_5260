

using DO;
using System.Net;

namespace Dal;

public class DalOrder
{
    public static int Add(DO.Order ord)
    {
   
        ord.ID = DataSource.Config.orderId;
        DataSource.orderArr[DataSource.Config.productNum] = ord;
        DataSource.Config.productNum++;
        return ord.ID;
    }

    public static DO.Order Get(int num)
    {
        DO.Order ord = new DO.Order();
        for(int i=0; i<DataSource.orderArr.Length; i++)
        {
            if(DataSource.orderArr[i].ID == num)
                ord = DataSource.orderArr[i];
        }
        return ord;
    }

    public static DO.Order[] GetAll()
    {
        DO.Order[] ord = new DO.Order[DataSource.orderArr.Length];
        for(int i=0; i<ord.Length; i++)
            ord[i] = DataSource.orderArr[i];
        return ord;
    }

    public static List<string> GetDetalies(int IDnum)
    {
        List<string> list = new List<string>();
        for(int i=0; i<DataSource.orderArr.Length; i++)
        {
            if (DataSource.orderArr[i].ID == IDnum)
            {
                list.Add(DataSource.orderArr[i].CostumerName);
                list.Add(DataSource.orderArr[i].CostumerEmail);
                list.Add(DataSource.orderArr[i].CostumerAddress);
                list.Add(DataSource.orderArr[i].OrderDate.ToString());
                list.Add(DataSource.orderArr[i].ShipDate.ToString());
                list.Add(DataSource.orderArr[i].DeliveryDate.ToString());
            }
        }
        if (list.Count > 0)
            return list;
        else
            throw new Exception("the order doesn't exist");
    }
    public static void Delete(int num)
    {
        for(int i=0; i<DataSource.orderArr.Length; i++)
        {
            if (DataSource.producrArr[i].ID==num) 
                DataSource.producrArr[i].ID = 0;
        }
    }

    public static void Update(DO.Order ord)
    {
        for(int i=0; i<DataSource.orderArr.Length; i++)
        {
            if (DataSource.orderArr[i].ID == ord.ID)
            {
                DataSource.orderArr[i].OrderDate=ord.OrderDate;
                DataSource.orderArr[i].ShipDate=ord.ShipDate;
                DataSource.orderArr[i].DeliveryDate=ord.DeliveryDate;
                DataSource.orderArr[i].CostumerName=ord.CostumerName;
                DataSource.orderArr[i].CostumerEmail=ord.CostumerEmail;
                DataSource.orderArr[i].CostumerAddress=ord.CostumerAddress;
            }
            else
                throw new Exception("the order doesn't exist");
        }
    }
}
