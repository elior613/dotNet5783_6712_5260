

namespace BO
{
    public class Order
    {
        public int ID { get; set; }//the ID with which we will selet the desired object
        public string CostumerName { get; set; }//the name of the costumer
        public string CostumerEmail { get; set; }//email of costumer
        public string CostumerAddress { get; set; }//address of costumer
        public DateTime OrderDate { get; set; }// the date of the order
        public DateTime ShipDate { get; set; }//the date of the ship
        public DateTime DeliveryDate { get; set; }//the date of the delivery
        public double TotalPrice { get; set; }//a total price of order
        public IEnumerable<OrderItem> Items { get; set; }//a list of the items
        public OrderStatus Status { get; set; }//the status of the orders



        //to show the details when asked
        public override string ToString() => $@"
Order ID: {ID}, Costumer details: {CostumerName},{CostumerEmail}, {CostumerAddress}, 
Order date:{OrderDate}, Ship date: {ShipDate}, Delivery date: {DeliveryDate},
Total price: {TotalPrice}, Items: {Items}, Status: {Status}
    ";
    }
}
