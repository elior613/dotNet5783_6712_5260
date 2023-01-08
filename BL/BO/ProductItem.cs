

namespace BO
{
    public class ProductItem
    {
        public int ID { get; set; }//the name of the product
        public bool InStock { get; set; }//if there is in stock
        public int Amount { get; set; }//how many there is in the shopping cart
        public string Name { get; set; }//the name of the product
        public double Price { get; set; }//the price of the product
        public Furniture Furniture { get; set; }//the category of the product


        //to show all the details of the product
        public override string ToString() => $@"
Product ID: {ID}, Name: {Name}, Category: {Furniture}
Price: {Price}, in stock: {InStock}, Amount in the cart:{Amount}
    ";
    }
}
