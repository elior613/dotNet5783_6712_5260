using BlApi;
using BO;
using Dal;
using DalApi;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using static BO.Exceptions;

namespace BlImplementation
{
    internal class Order : BlApi.IOrder
    {
        private IDal Dal = new DalList();

        IEnumerable<OrderForList?>? BlApi.IOrder.GetOrders()
        {
            int count = 0;
            double total = 0;
            List<OrderForList> orderForLists=new List<OrderForList?>();
            BO.OrderForList order = new BO.OrderForList();
            IEnumerable <DO.Order> orders= Dal.Order.GetAll();
            foreach(DO.Order ord in orders)
            {
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
                        foreach(DO.OrderItem oi in Dal.OrderItem.GetAll())
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

        BO.Order? BlApi.IOrder.Get(int id)
        {
            if (id > 0)
            {
                int prodID=0; 
                BO.Order ord=new BO.Order(); 
                DO.Order order= Dal.Order.Get(id);
                ord.ID=order.ID;
                ord.CostumerName=order.CostumerName;
                ord.CostumerAddress=order.CostumerAddress;
                ord.CostumerEmail=order.CostumerEmail;
                ord.DeliveryDate=order.DeliveryDate;
                ord.ShipDate=order.ShipDate;
                ord.OrderDate=order.OrderDate;
                foreach(DO.OrderItem oi in Dal.OrderItem.GetAll())
                {
                    if(oi.OrderID==ord.ID)
                        prodID = oi.ProductID;
                }
                foreach(BO.OrderItem oi in GetOrderItems())
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

        BO.Order? BlApi.IOrder.Update(int id)
        {
            BO.Order thisOrder=new BO.Order();
            DO.Order ord = Dal.Order.Get(id);
            if (ord.ShipDate==DateTime.MinValue)
            {
                ord.ShipDate = DateTime.Now;
                Dal.Order.Update(ord);
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
            DO.Order ord = Dal.Order.Get(id);
            if (ord.DeliveryDate == DateTime.MinValue)
            {
                ord.DeliveryDate = DateTime.Now;
                Dal.Order.Update(ord);
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

        BO.OrderTracking? BlApi.IOrder.Tracking(int id)
        {
            DO.Order ord = Dal.Order.Get(id);
            if (ord.ID == id)
            {
                Tuple<DateTime, BO.OrderStatus>[] DStatus = new Tuple<DateTime, BO.OrderStatus>[3];
                DStatus[0]= new Tuple<DateTime, BO.OrderStatus>(ord.OrderDate,BO.OrderStatus.confirmed);
                DStatus[0] = new Tuple<DateTime, BO.OrderStatus>(ord.ShipDate, BO.OrderStatus.shipped);
                DStatus[0] = new Tuple<DateTime, BO.OrderStatus>(ord.DeliveryDate, BO.OrderStatus.delivered);

                BO.OrderTracking tracking=new BO.OrderTracking();
                tracking.ID= id;
                if (ord.DeliveryDate != DateTime.MinValue)
                    tracking.Status = BO.OrderStatus.delivered;
                else if (ord.ShipDate != DateTime.MinValue)
                    tracking.Status = BO.OrderStatus.shipped;
                else
                    tracking.Status = BO.OrderStatus.confirmed;
                tracking.OrderStatus = DStatus;
                return tracking;
            }
            else
                throw new DoesnotExistException();
        }

          IEnumerable<BO.OrderItem> GetOrderItems() //a help method for the method Get
        {
            IEnumerable<DO.OrderItem> orderItems = Dal.OrderItem.GetAll();
            List<BO.OrderItem> list = new List<BO.OrderItem>();
            BO.OrderItem oi=new BO.OrderItem();
            foreach(DO.OrderItem item in orderItems)
            {
                oi.ID=item.ID;
                oi.ProductID=item.ProductID;
                oi.Amount=item.Amount;
                oi.Price=item.Price;
                foreach(DO.Product product in Dal.Product.GetAll())
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
            IEnumerable<DO.Order> orders = Dal.Order.GetAll();
            List<BO.Order> list = new List<BO.Order>();
            BO.Order order = new BO.Order();
            foreach (DO.Order ord in orders)
            {
                order.ID = ord.ID;
                order.CostumerName = ord.CostumerName;
                order.CostumerEmail = ord.CostumerEmail;
                order.CostumerAddress = ord.CostumerAddress;
                order.OrderDate = ord.OrderDate;
                order.ShipDate = ord.ShipDate;
                order.DeliveryDate = ord.DeliveryDate;
                DO.OrderItem oitem = new DO.OrderItem();
                foreach (DO.OrderItem oi in Dal.OrderItem.GetAll())
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
