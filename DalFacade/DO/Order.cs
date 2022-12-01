
namespace DO;

public struct Order
{   public int ID { get ; set; }
    private string costumerName, costumerEmail, costumerAddress;
    public string CostumerName { get; set; }
    public string CostumerEmail { get; set; }

    public string CostumerAddress { get; set; }
    private DateTime orderDate, shipDate, deliveryDate;
    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }
    public DateTime DeliveryDate { get; set; }

    public override string ToString() => $@"
        Order ID = {ID}, Costumer details: {CostumerName},{CostumerEmail}, {CostumerAddress}, 
        Order date:{OrderDate}, Ship date: {ShipDate}, Delivery date: {DeliveryDate}
    ";
}
