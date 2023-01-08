

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }//the id of the order
        public OrderStatus Status { get; set; }//the status of the order

        //to show the details when asked
        public override string ToString() => $@"
Order ID: {ID},Status: {Status}
    ";
    }
}
