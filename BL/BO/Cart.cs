

namespace BO
{
    public class Cart
    {
        public string CostumerName { get; set; }//the name of the costumer
        public string CostumerEmail { get; set; }//the email of the costumer
        public string CostumerAddress { get; set; }//the address of the costumer
        public IEnumerable<OrderItem>? Items { get; set; }//a list of the items
        internal double TotalPrice { get; set; }//the total price

        //to show the details when asked
        public override string ToString() => $@"
Costumer details: {CostumerName},{CostumerEmail}, {CostumerAddress}, 
Total price: {TotalPrice}, Items: {Items}
    ";
    }
}
