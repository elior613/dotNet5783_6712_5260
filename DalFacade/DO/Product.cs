

namespace DO;

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
    public override string ToString() => $@"
        Product ID = {id}, {name}, Category - {furniture}
Price: {price}, Amount in stock: {inStock}
    ";
}
