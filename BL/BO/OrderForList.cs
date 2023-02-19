
namespace BO
{
    public class OrderForList
    {
        public int ID { get; set; }//the ID with which we will selet the desired object
        public string? CostumerName { get; set; }//the name of the costumer
        public OrderStatus Status { get; set; }//the status of the order
        public int AmountOfItems { get; set; }//amount of items
        public double TotalPrice { get; set; }//the total price
        public DateTime? OrderDate { get; set; }


        //printing the details when needed
        public override string ToString() => $@"
ID: {ID}, Costumer Name:{CostumerName}, Status: {Status}
Amount of items:{AmountOfItems}, Total price: {TotalPrice}
    ";
    }
}
