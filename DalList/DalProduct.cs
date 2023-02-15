

using DO;
using System.Security.Cryptography;
using System.Collections;
using DalApi;
using System.Linq;

namespace Dal;

internal class DalProduct:IProduct 
{
    DataSource dataSource = DataSource.Instance;
    public  int Add(DO.Product prod)//adding a new product in our list of product.
    {
        for(int i = 0; i < dataSource.producrArr.Count; i++)//checking if the product already exist or not
        {
            if (dataSource.producrArr[i]?.ID == prod.ID)
                        throw new ExistException();//if the new product was in fact an existing product
        }
        //initializing the correct name of the product
        prod.Name = dataSource.initializingName(prod);
        //initializing the correct num of price
        prod.Price=dataSource.initializingPrice(prod);
        //initializing the correct num of the count in the stock
        prod.InStock=dataSource.initializingInStock(prod);

        dataSource.producrArr.Add(prod);
        Console.WriteLine("The product has been successfully added");//confirmation of the creation of the new product
        return prod.ID; 
    }
 

public  DO.Product  Get (int num)//getting a product 
    {
    DO.Product prod = new DO.Product();
        for (int i = 0; i < dataSource.producrArr.Count; i++)//looking for the product in the array thanks to an num corresponding to an ID
        {
            if (dataSource.producrArr[i]?.ID == num)
            {
                prod = (DO.Product)dataSource.producrArr?[i];
                return prod;
            }
    }
        throw new DoesntExistException();

    }

    public Product? Get(Func<Product?, bool>? function)
    {
        /*
        var v = from item in dataSource.producrArr // stage 5 
                where function(item)
                select item;
        return v.FirstOrDefault(); // return the product or null
        */
        
        foreach (var item in dataSource.producrArr)
            if (function(item))
                return item.Value;
        throw new DoesntExistException("Product doesn't exist"); 
        
    }


    public IEnumerable<Product?> GetAll(Func<Product?, bool>? function) =>
    (function == null ? dataSource.producrArr.Select(item => item) : dataSource.producrArr.Where(function))
    ?? throw new DoesntExistException("Missing products");

    public void Delete(int num)//deleting the product thanks to an num corresponding to the ID
    {
        for (int i = 0; i < dataSource.producrArr.Count; i++)
        {
            if (dataSource.producrArr[i]?.ID == num)
            {
                dataSource.producrArr.Remove(dataSource.producrArr[i]);
                Console.WriteLine("The product has been successfully deleted");
                return;
            }
        }
        throw new DoesntExistException();
    }

    public  void Update(DO.Product? prod)//updating all the details about a product
    {
        for (int i = 0; i < dataSource.producrArr.Count; i++)
        {
            if (dataSource.producrArr[i]?.ID == prod?.ID)
            {
                dataSource.producrArr[i]=prod;
                Console.WriteLine("The product has been updated successfully");
                return;
            }
        }
                 throw new DoesntExistException();
    }
}
