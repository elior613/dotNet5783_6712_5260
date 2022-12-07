

namespace Dal;

public class DalOrderItem
{
    DataSource dataSource = DataSource.Instance;
    public  int Add(DO.OrderItem oi)
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
        for(int i = 0; i < dataSource.orderItemArr.Length; i++)
        {
            if (dataSource.orderItemArr[i].id==num)
                oi= dataSource.orderItemArr[i];

            
        }
        if (oi.id != num)
            throw new Exception("The object doesn't exist.");
            return oi;
    }

    public  DO.OrderItem[] GetAll()
    {
       DO.OrderItem[] oi=new DO.OrderItem[dataSource.orderItemArr.Length];
        for(int i = 0; i < oi.Length; i++)
            oi[i] = dataSource.orderItemArr[i];
        return oi;
    }

    public  DO.OrderItem GetOrderItem(int prodId,int ordId)
    {
        DO.OrderItem oi = new DO.OrderItem();
        for(int i=0; i < dataSource.orderItemArr.Length; i++)
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
                dataSource.orderItemArr[i].id = 0;
                Console.WriteLine("The order item has been successfully deleted");
                return;
            }
        }
        throw new Exception("the order item doesn't exist");
    }

    public  void Update(DO.OrderItem oi)
    {
        for (int i = 0; i < dataSource.orderItemArr.Length; i++)
        {
            if (dataSource.orderItemArr[i].id == oi.id)
            {
                dataSource.orderItemArr[i].OrderID = oi.OrderID;
                dataSource.orderItemArr[i].ProductID = oi.ProductID;
                dataSource.orderItemArr[i].Amount = oi.Amount;
                dataSource.orderItemArr[i].Price = oi.Price;
                Console.WriteLine("The order item has been updated successfully");
                return;
            }
        }
                throw new Exception("the order item doesn't exist");
    }

}
