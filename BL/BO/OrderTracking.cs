

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }//the id of the order
        public OrderStatus Status { get; set; }//the status of the order
        public IEnumerable<Tuple<DateTime?, string>?> OrderStatus { get; set; }

        //to show the details when asked
        public override string ToString()
        {
            string str = "order id:" + ID + '\n' +
                               "order status:" + Status + '\n' +
                                "order description:" + '\n';
            foreach (Tuple<DateTime?, string> t in OrderStatus!)
            {
                str += t.Item2 + '\n';
            }

            return str;
            //  return this.ToStringProperty();
        }
    }
}
