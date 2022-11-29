

using System.Security.Cryptography;

namespace Dal;

public class DalProduct
{
    DataSource _dataSource = DataSource.Instance;
    public  int Add(DO.Product prod)
    {
        for(int i = 0; i < _dataSource.producrArr.Length; i++)
        {
            if (_dataSource.producrArr[i].ID == prod.ID)
                        throw new Exception("the product already exist");
        }
        _dataSource.producrArr[DataSource.Config.productNum] = prod;
        return DataSource.Config.productNum; 
    }
 

public  DO.Product Get (int num){
    DO.Product prod = new DO.Product();
    for(int i=0; i < _dataSource.producrArr.Length; i++)
    {
        if (_dataSource.producrArr[i].ID == num)
            prod= _dataSource.producrArr[i];
    }
    return prod;
    }

    public  DO.Product[] GetAll()
    {
     DO.Product[] prod = new DO.Product[_dataSource.producrArr.Length]; 
        for(int i=0; i < _dataSource.producrArr.Length; i++)
            prod[i] = _dataSource.producrArr[i];
        return prod;
    }

    public  void Delete(int num)
    {
        for(int i=0; i < _dataSource.producrArr.Length; i++)
        {
            if(_dataSource.producrArr[i].ID == num)
                _dataSource.producrArr[i].ID = 0;
        }
    }

    public  void Update(DO.Product prod)
    {
        for(int i=0; i < _dataSource.producrArr.Length; i++)
        {
            if (_dataSource.producrArr[i].ID == prod.ID)
            {
                _dataSource.producrArr[i].Furniture = prod.Furniture;
                _dataSource.producrArr[i].InStock = prod.InStock;
                _dataSource.producrArr[i].Price = prod.Price;
                _dataSource.producrArr[i].Name = prod.Name;
            }
            else
                throw new Exception("the product doesn't exist");
        }
    }
}
