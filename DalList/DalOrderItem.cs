﻿

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
            if (dataSource.orderItemArr[i].id == oi.id)
                throw new ExistException();
                }
        oi.id = DataSource.Config.OrderItemId;
        oi.OrderID = rand.Next(1,dataSource.orderArr.Count());
        oi.ProductID = rand.Next(100000,100000+dataSource.producrArr.Count());
        oi.Amount = rand.Next(0, 100);
        oi.Price = rand.Next(30, 300);
        dataSource.orderItemArr.Add(oi);
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
            throw new DoesntExistException();
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
            throw new DoesntExistException();
    }
    public  void Delete(int num)
    {
        for(int i = 0; i < dataSource.orderItemArr.Count(); i++)
        {
            if (dataSource.orderItemArr[i].id == num)
            {
                dataSource.orderItemArr.Remove(dataSource.orderItemArr[i]);
                Console.WriteLine("The order item has been successfully deleted");
                return;
            }
        }
        throw new DoesntExistException();
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
        throw new DoesntExistException();
    }

}
