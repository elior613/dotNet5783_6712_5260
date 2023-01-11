

namespace BO
{
    public class Cart
    {
        string CostumerName { get; set; }//the name of the costumer
        string CostumerEmail { get; set; }//the email of the costumer
        string CostumerAddress { get; set; }//the address of the costumer
        public IEnumerable<OrderItem>? Items { get; set; }//a list of the items
        double TotalPrice { get; set; }//the total price

        //to show the details when asked
        public override string ToString() => $@"
Costumer details: {CostumerName},{CostumerEmail}, {CostumerAddress}, 
Total price: {TotalPrice}, Items: {Items}
    ";
    }
}
