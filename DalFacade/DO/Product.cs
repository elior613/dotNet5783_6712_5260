

namespace DO;

//product structur 
public struct Product
{
    private int id, inStock;
    public int ID { get; set; }
    public int InStock { get; set; }
    private string name;
    public string Name { get; set; }
    private double price;
    public double Price { get; set; }
    private Furniture furniture;
    public Furniture Furniture { get; set; }


    //to show all the details of the product
    public override string ToString() => $@"
    Product ID: {ID}, Name: {Name}, Category: {Furniture}
    Price: {Price}, Amount in stock: {InStock}
    ";
}
