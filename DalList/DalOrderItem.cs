

using DalApi;
using DO;
using System.Diagnostics;

namespace Dal;

internal class DalOrderItem:IOrderItem
{
    DataSource dataSource = DataSource.Instance;
    static readonly Random rand = new Random();

    public int Add(OrderItem oi)
    {
        for (int i = 0; i < dataSource.orderItemArr.Count(); i++) {
            if (dataSource.orderItemArr[i]?.ID == oi.ID)
                throw new ExistException();
                }
        oi.ID = DataSource.Config.OrderItemId;
        if(oi.OrderID<1||oi.OrderID>dataSource.orderArr.Count())
            oi.OrderID = rand.Next(1, dataSource.orderArr.Count());
        oi.ProductID = rand.Next(100000,100000+dataSource.producrArr.Count());
        foreach(Product product in dataSource.producrArr)
        {
            if (product.ID == oi.ProductID)
            {
                oi.Price=product.Price;
                oi.Amount = product.InStock;
            }
        }
        dataSource.orderItemArr.Add(oi);
        DataSource.Config.orderItemNum++;
        Console.WriteLine("The order item has been successfully added");
        return oi.ID;
    }
    public  DO.OrderItem Get(int num)
    {
        DO.OrderItem oi=new DO.OrderItem();
        for(int i = 0; i < dataSource.orderItemArr.Count; i++)
        {
            if (dataSource.orderItemArr[i]?.ID==num)
                oi= (DO.OrderItem)dataSource.orderItemArr?[i];

            
        }
        if (oi.ID != num)
            throw new DoesntExistException();
            return oi;
    }
    public OrderItem? Get(Func<OrderItem?, bool>? function)
    {
        foreach (var item in dataSource.orderItemArr)
            if (function(item))
                return item;
        throw new DoesntExistException("OrderItem doesn't exist");
/*
        var v = from item in dataSource.orderItemArr 
                where function(item)
                select item;
        return v.FirstOrDefault(); // return the product or null
*/
    }
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? function = null) =>

       (function == null ?
                     dataSource.orderItemArr.Select(item => item) :
                     dataSource.orderItemArr.Where(function))
   ?? throw new DoesntExistException("Missing Order Item");

    /* public  DO.OrderItem? GetOrderItem(int prodId,int ordId)
     {
         DO.OrderItem? oi = new DO.OrderItem();
         for(int i=0; i < dataSource.orderItemArr.Count; i++)
         {
             if (dataSource.orderItemArr[i]?.ProductID == prodId && dataSource.orderItemArr[i]?.OrderID==ordId)
                 oi= dataSource.orderItemArr?[i];
         }
         if(oi?.OrderID==ordId&&oi?.ProductID==prodId)
         return oi;
         else
             throw new DoesntExistException();
     }
    */
    public  void Delete(int num)
    {
        for(int i = 0; i < dataSource.orderItemArr.Count(); i++)
        {
            if (dataSource.orderItemArr[i]?.ID == num)
            {
                dataSource.orderItemArr.Remove(dataSource.orderItemArr[i]);
                Console.WriteLine("The order item has been successfully deleted");
                return;
            }
        }
        throw new DoesntExistException();
    }

    public  void Update(DO.OrderItem? oi)
    {
        for (int i = 0; i < dataSource.orderItemArr.Count; i++)
        {
            if (dataSource.orderItemArr[i]?.ID == oi?.ID)
            {
                dataSource.orderItemArr[i] = oi;
                Console.WriteLine("The order item has been updated successfully");
                return;
            }
        }
        throw new DoesntExistException();
    }

}
