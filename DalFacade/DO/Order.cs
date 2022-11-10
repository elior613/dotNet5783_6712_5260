
namespace DO;

public struct Order
{
    private int id;
    public int ID { get; set; }
    private string costumerName, costumerEmail, costumerAddress;
    public string CostumerName { get; set; }
    public string CostumerEmail { get; set; }

    public string CostumerAddress { get; set; }
    private DateTime orderDate, shipDate, deliveryDate;
    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }
    public DateTime DeliveryDate { get; set; }

    public override string ToString() => $@"
        Order ID = {id}, Costumer details: {costumerName},{costumerEmail}, {costumerAddress}, 
        Order date:{orderDate}, Ship date: {shipDate}, Delivery date: {deliveryDate}
    ";
}
