
namespace DO;


//order item structure 
public struct OrderItem
{
    private int ID, productID, orderID;
    public int id { get; set; }
    public int ProductID { get; set; }
    public int OrderID { get; set; }
    private double price;
    public double Price { get; set; }
    private int amount;
    public int Amount { get; set; }
    //printing the details when needed
    public override string ToString() => $@"
         ID: {id}, Product ID: {ProductID}, Order ID: {OrderID},
         Price: {Price}, Amount: {Amount}
    ";
}
