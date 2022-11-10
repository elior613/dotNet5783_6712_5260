
namespace DO;

public struct OrderItem
{
    private int productID, orderID;
    public int ProductID { get; set; }
    public int OrderID { get; set; }
    private double price;
    public double Price { get; set; }
    private int amount;
    public int Amount { get; set; }

    public override string ToString() => $@"
         ID = {productID}, {orderID},
Price: {price}, Amount: {amount}
    ";
}
