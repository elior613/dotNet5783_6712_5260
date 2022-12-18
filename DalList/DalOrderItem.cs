

using DalApi;
using DO;

namespace Dal;

internal class DalOrderItem:IOrderItem
{
    DataSource dataSource = DataSource.Instance;
    public  int Add(OrderItem oi)
    {
        oi.id = DataSource.Config.orderItemId;
        oi.OrderID = DataSource.Config.orderId;
        dataSource.orderItemArr[DataSource.Config.orderItemNum] = oi;
        DataSource.Config.orderItemNum++;
        Console.WriteLine("The order item has been successfully added");
        return oi.id;
    }
    public  DO.OrderItem Get(int num)
    {
        DO.OrderItem oi=new DO.OrderItem();
        for(int i = 0; i < dataSource.orderItemArr.Count; i++)
        {
            if (dataSource.orderItemArr[i].id==num)
                oi= dataSource.orderItemArr[i];

            
        }
        if (oi.id != num)
            throw new Exception("The object doesn't exist.");
            return oi;
    }

    public  IEnumerable<OrderItem> GetAll()
    {
        IEnumerable<OrderItem> oi =dataSource.orderItemArr;
        return oi;
    }

    public  DO.OrderItem GetOrderItem(int prodId,int ordId)
    {
        DO.OrderItem oi = new DO.OrderItem();
        for(int i=0; i < dataSource.orderItemArr.Count; i++)
        {
            if (dataSource.orderItemArr[i].ProductID == prodId && dataSource.orderItemArr[i].OrderID==ordId)
                oi= dataSource.orderItemArr[i];
        }
        if(oi.OrderID==ordId&&oi.ProductID==prodId)
        return oi;
        else
            throw new Exception("the order item doesn't exist");
    }
    public  void Delete(int num)
    {
        for(int i = 0; i < DataSource.Config.orderItemNum; i++)
        {
            if (dataSource.orderItemArr[i].id == num)
            {
                dataSource.orderItemArr.Remove(dataSource.orderItemArr[i]);
                Console.WriteLine("The order item has been successfully deleted");
                return;
            }
        }
        throw new Exception("the order item doesn't exist");
    }

    public  void Update(DO.OrderItem oi)
    {
        for (int i = 0; i < dataSource.orderItemArr.Count; i++)
        {
            if (dataSource.orderItemArr[i].id == oi.id)
            {
                dataSource.orderItemArr[i] = oi;
                Console.WriteLine("The order item has been updated successfully");
                return;
            }
        }
                throw new Exception("the order item doesn't exist");
    }

}
