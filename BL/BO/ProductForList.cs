using DO;



namespace BO
{
    public class ProductForList
    {
        public int ID { get; set; }//the name of the product
        public string? Name { get; set; }//the name of the product
        public double Price { get; set; }//the price of the product
        public Furniture Furniture { get; set; }//the category of the product


        //to show all the details of the product
        public override string ToString() => $@"
Product ID: {ID},   Name: {Name}, 
Category: {Furniture},   Price: {Price}
    ";
    }
}
