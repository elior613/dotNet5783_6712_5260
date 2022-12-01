
namespace DO;

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

    public override string ToString() => $@"
         ID = {id}, {ProductID}, {OrderID},
Price: {Price}, Amount: {Amount}
    ";
}
