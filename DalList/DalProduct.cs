

using System.Security.Cryptography;

namespace Dal;

public class DalProduct
{
    DataSource dataSource = DataSource.Instance;
    public  int Add(DO.Product prod)//adding a new product in our list of product.
    {
        for(int i = 0; i < dataSource.producrArr.Length; i++)//checking if the product already exist or not
        {
            if (dataSource.producrArr[i].ID == prod.ID)
                        throw new Exception("the product already exist");//if the new product was in fact an existing product
        }
        dataSource.producrArr[DataSource.Config.productNum] = prod;
        Console.WriteLine("The product has been successfully added");//confirmation of the creation of the new product
        return DataSource.Config.productNum; 
    }
 

public  DO.Product Get (int num)//getting a product 
    {
    DO.Product prod = new DO.Product();
        for (int i = 0; i < dataSource.producrArr.Length; i++)//looking for the product in the array thanks to an num corresponding to an ID
        {
            if (dataSource.producrArr[i].ID == num)
            {
                prod = dataSource.producrArr[i];
                return prod;
            }
    }
        throw new Exception("the product doesn't exist");

    }

    public  DO.Product[] GetAll()//putting all the product in an array and returning the pointer of the array
    {
     DO.Product[] prod = new DO.Product[dataSource.producrArr.Length]; 
        for(int i=0; i < dataSource.producrArr.Length; i++)
            prod[i] = dataSource.producrArr[i];
        return prod;
    }

    public void Delete(int num)//deleting the product thanks to an num corresponding to the ID
    {
        for (int i = 0; i < dataSource.producrArr.Length; i++)
        {
            if (dataSource.producrArr[i].ID == num)
            {
                dataSource.producrArr[i].ID = 0;
                Console.WriteLine("The product has been successfully deleted");
                return;
            }
        }
        throw new Exception("the product doesn't exist");
    }

    public  void Update(DO.Product prod)//updating all the details about a product
    {
        for (int i = 0; i < dataSource.producrArr.Length; i++)
        {
            if (dataSource.producrArr[i].ID == prod.ID)
            {
                dataSource.producrArr[i].Furniture = prod.Furniture;
                dataSource.producrArr[i].InStock = prod.InStock;
                dataSource.producrArr[i].Price = prod.Price;
                dataSource.producrArr[i].Name = prod.Name;
                Console.WriteLine("The product has been updated successfully");
                return;
            }
        }
                throw new Exception("the product doesn't exist");
    }
}
