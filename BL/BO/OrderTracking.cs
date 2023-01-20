

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }//the id of the order
        public OrderStatus Status { get; set; }//the status of the order
        public IEnumerable<Tuple<DateTime, OrderStatus>> OrderStatus { get; set; }

        //to show the details when asked
        public override string ToString() => $@"
Order ID: {ID},Status: {Status}, Order Status: {OrderStatus}
    ";
    }
}
