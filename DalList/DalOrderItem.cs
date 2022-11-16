

namespace Dal;

public class DalOrderItem
{
    public static int Add(DO.OrderItem oi)
    {
        oi.id = DataSource.Config.orderItemId;
        oi.OrderID = DataSource.Config.orderId;
        DataSource.orderItemArr[DataSource.Config.orderItemNum] = oi;
        DataSource.Config.orderItemNum++;
        return oi.id;
    }
    public static DO.OrderItem Get(int num)
    {
        DO.OrderItem oi=new DO.OrderItem();
        for(int i = 0; i < DataSource.Config.orderItemNum; i++)
        {
            if (DataSource.orderItemArr[i].id==num)
                oi= DataSource.orderItemArr[i];

        }
        return oi;
    }

    public static DO.OrderItem[] GetAll()
    {
       DO.OrderItem[] oi=new DO.OrderItem[DataSource.orderItemArr.Length];
        for(int i = 0; i < oi.Length; i++)
            oi[i] = DataSource.orderItemArr[i];
        return oi;
    }

    public static DO.OrderItem GetOrderItem(int prodId,int ordId)
    {
        DO.OrderItem oi = new DO.OrderItem();
        for(int i=0; i < DataSource.orderItemArr.Length; i++)
        {
            if (DataSource.orderItemArr[i].ProductID == prodId && DataSource.orderItemArr[i].OrderID==ordId)
                oi= DataSource.orderItemArr[i];
        }
        if(oi.OrderID==ordId&&oi.ProductID==prodId)
        return oi;
        else
            throw new Exception("the order item doesn't exist");
    }
    public static void Delete(int num)
    {
        for(int i = 0; i < DataSource.Config.orderItemNum; i++)
        {
            if (DataSource.orderItemArr[i].id == num)
                DataSource.orderItemArr[i].id = 0;
        }
    }

    public static void Update(DO.OrderItem oi)
    {
        for(int i = 0; i < DataSource.orderItemArr.Length; i++)
        {
            if (DataSource.orderItemArr[i].id == oi.id)
            {
                DataSource.orderItemArr[i].OrderID = oi.OrderID;
                DataSource.orderItemArr[i].ProductID = oi.ProductID;
                DataSource.orderItemArr[i].Amount = oi.Amount;
                DataSource.orderItemArr[i].Price = oi.Price;
            }
            else
                throw new Exception("the order item doesn't exist");
        }
    }

}
