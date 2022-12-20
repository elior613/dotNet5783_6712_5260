using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal
{
    sealed public class DalList : IDal
    {
        public IProduct Product { get; } = new DalProduct();
        public IOrder Order { get; } = new DalOrder();
        public IOrderItem OrderItem { get; } = new DalOrderItem();
    }
}
