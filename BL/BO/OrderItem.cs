using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BOOrderItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }
        //printing the details when needed
        public override string ToString() => $@"
         ID: {ID}, Product ID: {ProductID}, Order ID: {OrderID},
         Price: {Price}, Amount: {Amount}
    ";
    }
}
