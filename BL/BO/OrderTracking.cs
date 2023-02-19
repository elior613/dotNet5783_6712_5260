

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }//the id of the order
        public OrderStatus Status { get; set; }//the status of the order
        public IEnumerable<Tuple<DateTime?, string?>?>? Tracking { get; set; }//OrderStatus

        //to show the details when asked
        public override string ToString()
        {
            string str = "order id:" + ID + '\n' +
                               "order status:" + Status + '\n' +
                                "order description:" + '\n';
            foreach (Tuple<DateTime?, string> t in Tracking!)
            {
                str += t.Item2 + '\n';
            }

            return str;
            //  return this.ToStringProperty();
        }
    }
}
