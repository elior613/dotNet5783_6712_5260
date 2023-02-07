 using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// Interface IOrder
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Return the order list
        /// </summary>
        /// <returns></returns>
        /// 
        IEnumerable<OrderForList?>? GetOrders();

        /// <summary>
        /// return order depending of it's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        Order? Get(int id);


        /// <summary>
        /// Only for Admin : Updating order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        Order? Update(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        Order updateDelivery(int id);

        /// <summary>
        /// For tracking the Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        OrderTracking? Tracking(int id);

       


        //int Add(IOrder order);

    }
}
