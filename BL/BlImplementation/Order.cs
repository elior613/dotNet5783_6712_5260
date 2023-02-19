using BlApi;
using BO;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using static BO.Exceptions;

namespace BlImplementation
{
    internal class Order : BlApi.IOrder
    {
        DalApi.IDal? dal = DalApi.Factory.Get();
        IEnumerable<OrderForList?>? BlApi.IOrder.GetOrders()
        {
            int count = 0;
            double total = 0;
            List<OrderForList> orderForLists=new List<OrderForList?>();
            IEnumerable <DO.Order?> orders= dal.Order.GetAll();
            foreach(DO.Order ord in orders)
            {
                BO.OrderForList order = new BO.OrderForList();
                order.ID= ord.ID;
                order.CostumerName= ord.CostumerName;
                if (ord.DeliveryDate != DateTime.MinValue)
                    order.Status = BO.OrderStatus.delivered;
                else if (ord.ShipDate != DateTime.MinValue)
                    order.Status = BO.OrderStatus.shipped;
                else
                    order.Status = BO.OrderStatus.confirmed;
                foreach (DO.Order or in orders)
                {
                    if (or.CostumerName == ord.CostumerName)
                    {
                        count++;
                        foreach(DO.OrderItem oi in dal.OrderItem.GetAll(null))
                        {
                            if (oi.ID == ord.ID)
                                total += oi.Price;
                        }
                    }
                } 

                order.AmountOfItems= count;
                order.TotalPrice = total;
                orderForLists.Add(order);
            }
            return orderForLists;
        }

        BO.Order BlApi.IOrder.Get(int id)
        {
            if (id > 0)
            {
                int prodID=0; 
                BO.Order? ord=new BO.Order(); 
                DO.Order? order= dal.Order.Get(id);
                ord.ID=(int)order?.ID;
                ord.CostumerName=order?.CostumerName;
                ord.CostumerAddress=order?.CostumerAddress;
                ord.CostumerEmail=order?.CostumerEmail;
                ord.DeliveryDate=order?.DeliveryDate;
                ord.ShipDate=order?.ShipDate;
                ord.OrderDate=order?.OrderDate;
                foreach(DO.OrderItem OI in dal.OrderItem.GetAll(null))
                {
                    if(OI.OrderID==ord.ID)
                        prodID = OI.ProductID;
                }
                foreach (BO.OrderItem oi in GetOrderItems())
                {
                    if (oi.ProductID == prodID)
                        ord.Item = oi;
                }
                 ord.TotalPrice=ord.Item.TotalPrice;
                if (ord.DeliveryDate != DateTime.MinValue)
                    ord.Status = BO.OrderStatus.delivered;
                else if (ord.ShipDate != DateTime.MinValue)
                    ord.Status = BO.OrderStatus.shipped;
                else
                    ord.Status = BO.OrderStatus.confirmed;

                return ord;
            }
            else
                throw new ErrorDetailsException();
        }

        BO.Order BlApi.IOrder.Update(int id)
        {
            BO.Order thisOrder=new BO.Order();
            DO.Order ord = dal.Order.Get(id);
            if (ord.ShipDate==DateTime.MinValue)
            {
          
                ord.ShipDate = DateTime.Now;
                dal.Order.Update(ord);
                foreach(BO.Order order in GetAllOrders())
                {
                    if (order.ID == id) {
                        order.ShipDate = ord.ShipDate;
                        order.Status= BO.OrderStatus.shipped;
                        thisOrder=order;
                    }
                }
                return thisOrder;

            }
            else
                throw new  ErrorDetailsException();
        }

        BO.Order BlApi.IOrder.updateDelivery(int id)
        {
            BO.Order thisOrder = new BO.Order();
            DO.Order ord = dal.Order.Get(id);
            if (ord.ShipDate!=DateTime.MinValue&&ord.DeliveryDate == DateTime.MinValue)
            {
                ord.DeliveryDate = DateTime.Now;
                dal.Order.Update(ord);
                foreach (BO.Order order in GetAllOrders())
                {
                    if (order.ID == id)
                    {
                        order.DeliveryDate = ord.DeliveryDate;
                        order.Status = BO.OrderStatus.delivered;
                        thisOrder = order;
                    }
                }
                return thisOrder;

            }
            else
                throw new ErrorDetailsException();
        }

        BO.OrderTracking BlApi.IOrder.Tracking(int id)
        {
            DO.Order ord = dal.Order.Get(id);
            if (ord.ID == id)
            {
       
                IEnumerable<Tuple<DateTime?, string?>> list;
                BO.OrderTracking tracking = new BO.OrderTracking();
                tracking.ID = id;
                if (ord.DeliveryDate != DateTime.MinValue)
                    tracking.Status = BO.OrderStatus.delivered;
                else if (ord.ShipDate != DateTime.MinValue)
                    tracking.Status = BO.OrderStatus.shipped;
                else
                    tracking.Status = BO.OrderStatus.confirmed;
                list = new List<Tuple<DateTime?, string>>
            {
                new Tuple<DateTime?, string>(ord.OrderDate, $"The Order {ord.ID} was ordered"),
                new Tuple<DateTime?, string>(ord.ShipDate, $"The Order {ord.ID} was shipped"),
                new Tuple<DateTime?, string>(ord.DeliveryDate, $"The Order {ord.ID} was delivered")
            };
                tracking.Tracking = list;
                return tracking;
            }
            else
                throw new DoesnotExistException();
        }

        List<BO.OrderItem> GetOrderItems() //a help method for the method Get
        {
            List<BO.OrderItem> list = new List<BO.OrderItem>();
            foreach(DO.OrderItem item in dal.OrderItem.GetAll())
            {
                BO.OrderItem oi = new BO.OrderItem();
                oi.ID=item.ID;
                oi.ProductID=item.ProductID;
                oi.Amount=item.Amount;
                oi.Price=item.Price;
                foreach(DO.Product product in dal.Product.GetAll())
                {
                    if(oi.ProductID==product.ID)
                        oi.Name=product.Name;
                }
            
                oi.TotalPrice=oi.Price*oi.Amount;
                list.Add(oi);
            }
            return list;
        }

        IEnumerable<BO.Order> GetAllOrders()//a help method for the method update
        {
            List<BO.Order> list = new List<BO.Order>();
            foreach (DO.Order ord in dal.Order.GetAll())
            {
                BO.Order order = new BO.Order();
                order.ID = ord.ID;
                order.CostumerName = ord.CostumerName;
                order.CostumerEmail = ord.CostumerEmail;
                order.CostumerAddress = ord.CostumerAddress;
                order.OrderDate = ord.OrderDate;
                order.ShipDate = ord.ShipDate;
                order.DeliveryDate = ord.DeliveryDate;
                DO.OrderItem oitem = new DO.OrderItem();
                foreach (DO.OrderItem oi in dal.OrderItem.GetAll(null))
                {
                    if (oi.OrderID == ord.ID)
                        oitem = oi;
                }
                foreach (BO.OrderItem item in GetOrderItems())
                {
                    if (item.ID == oitem.ID)
                        order.Item = item;
                }
                order.TotalPrice = order.Item.TotalPrice;
                if (ord.DeliveryDate != DateTime.MinValue)
                    order.Status = BO.OrderStatus.delivered;
                else if (ord.ShipDate != DateTime.MinValue)
                    order.Status = BO.OrderStatus.shipped;
                else
                    order.Status = BO.OrderStatus.confirmed;

                list.Add(order);
            }
            return list;
        }
        
    }
  
}
