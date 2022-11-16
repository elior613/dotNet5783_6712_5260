

using System.Security.Cryptography;

namespace Dal;

public class DalProduct
{
    public static int Add(DO.Product prod)
    {
        for(int i = 0; i < DataSource.producrArr.Length; i++)
        {
            if (DataSource.producrArr[i].ID == prod.ID)
                        throw new Exception("the product already exist");
        }
        DataSource.producrArr[DataSource.Config.productNum] = prod;
        return DataSource.Config.productNum; 
    }
 

public static DO.Product Get (int num){
    DO.Product prod = new DO.Product();
    for(int i=0; i < DataSource.producrArr.Length; i++)
    {
        if (DataSource.producrArr[i].ID == num)
            prod= DataSource.producrArr[i];
    }
    return prod;
    }

    public static DO.Product[] GetAll()
    {
     DO.Product[] prod = new DO.Product[DataSource.producrArr.Length]; 
        for(int i=0; i < DataSource.producrArr.Length; i++)
            prod[i] = DataSource.producrArr[i];
        return prod;
    }

    public static void Delete(int num)
    {
        for(int i=0; i < DataSource.producrArr.Length; i++)
        {
            if(DataSource.producrArr[i].ID == num)
                DataSource.producrArr[i].ID = 0;
        }
    }

    public static void Update(DO.Product prod)
    {
        for(int i=0; i < DataSource.producrArr.Length; i++)
        {
            if (DataSource.producrArr[i].ID == prod.ID)
            {
                DataSource.producrArr[i].Furniture = prod.Furniture;
                DataSource.producrArr[i].InStock = prod.InStock;
                DataSource.producrArr[i].Price = prod.Price;
                DataSource.producrArr[i].Name = prod.Name;
            }
            else
                throw new Exception("the product doesn't exist");
        }
    }
}
