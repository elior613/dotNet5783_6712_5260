 

namespace BO
{
    public class OrderItem
    {
        public int ID { get; set; }//the id of the order item
        public string Name { get; set; }//the name of the product
        public int ProductID { get; set; }//the id of the product
        public double Price { get; set; }//the price of the product
        public int Amount { get; set; }//the number of the quantity
        public double TotalPrice { get; set; }//the total price of the order

        //printing the details when needed
        public override string ToString() => $@"
ID: {ID}, Name:{Name}, Product ID: {ProductID},
Price: {Price}, Amount: {Amount}, Total price: {TotalPrice}
    ";
    }
}
