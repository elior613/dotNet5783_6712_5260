
namespace DO;

public struct Order//structur Order 
{   public int ID { get ; set; }//the ID with which we will selet the desired object

    public string CostumerName { get; set; }
    public string CostumerEmail { get; set; }

    public string CostumerAddress { get; set; }

    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }
    public DateTime DeliveryDate { get; set; }


    //to show the details when asked
    public override string ToString() => $@"
        Order ID: {ID}, Costumer details: {CostumerName},{CostumerEmail}, {CostumerAddress}, 
        Order date:{OrderDate}, Ship date: {ShipDate}, Delivery date: {DeliveryDate}
    ";
}
