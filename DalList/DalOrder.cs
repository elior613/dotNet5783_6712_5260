

using DO;
using System.Net;

namespace Dal;

public class DalOrder
{
    DataSource _dataSource = DataSource.Instance;
    public  int Add(DO.Order ord)
    {
   
        ord.ID = DataSource.Config.orderId;//adding a new ID for the new Order
        _dataSource.orderArr[DataSource.Config.productNum] = ord;//addingg the new order in the array with all the orders 
        DataSource.Config.productNum++;
        Console.WriteLine("The order has been successfully added");
        return ord.ID;
    }

    public  DO.Order Get(int num)
    {
        DO.Order ord = new DO.Order();
        for (int i = 0; i < _dataSource.orderArr.Length; i++)//get thanks to a loop in an array an order
        {
            if (_dataSource.orderArr[i].ID == num)
            {
                ord = _dataSource.orderArr[i];
                return ord;
            }
        }
        throw new Exception("the order doesn't exist");//if the order doesn't exist
    }

    public  DO.Order[] GetAll()
    {
        DO.Order[] ord = new DO.Order[_dataSource.orderArr.Length];//putting all the orders in an array and return the pointer to the array
        for(int i=0; i<ord.Length; i++)
            ord[i] = _dataSource.orderArr[i];
        return ord;
    }

    public  List<string> GetDetails(int IDnum)//showing all the details about an order depending of it's ID
    {
        List<string> list = new List<string>();
        for(int i=0; i< _dataSource.orderArr.Length; i++)
        {
            if (_dataSource.orderArr[i].ID == IDnum)
            {
                list.Add(_dataSource.orderArr[i].CostumerName);
                list.Add(_dataSource.orderArr[i].CostumerEmail);
                list.Add(_dataSource.orderArr[i].CostumerAddress);
                list.Add(_dataSource.orderArr[i].OrderDate.ToString());
                list.Add(_dataSource.orderArr[i].ShipDate.ToString());
                list.Add(_dataSource.orderArr[i].DeliveryDate.ToString());
            }
        }
        if (list.Count > 0)
            return list;
        else
            throw new Exception("the order doesn't exist");//sending a message if the order doesn't exist
    }
    public  void Delete(int num)//deleting an order in the array by remplacing his ID by 0
    {
        for(int i=0; i< _dataSource.orderArr.Length; i++)
        {
            if (_dataSource.producrArr[i].ID == num)
            {
                _dataSource.producrArr[i].ID = 0;
                Console.WriteLine("The order has been successfully deleted");
                return;
            }
        }
        throw new Exception("the order doesn't exist");//if the order didn't exist
    }

    public  void Update(DO.Order ord)//updating all the details about the order 
    {
        for (int i = 0; i < _dataSource.orderArr.Length; i++)
        {
            if (_dataSource.orderArr[i].ID == ord.ID)
            {
                _dataSource.orderArr[i].OrderDate = ord.OrderDate;
                _dataSource.orderArr[i].ShipDate = ord.ShipDate;
                _dataSource.orderArr[i].DeliveryDate = ord.DeliveryDate;
                _dataSource.orderArr[i].CostumerName = ord.CostumerName;
                _dataSource.orderArr[i].CostumerEmail = ord.CostumerEmail;
                _dataSource.orderArr[i].CostumerAddress = ord.CostumerAddress;
                Console.WriteLine("The order has been updated successfully");
                return;
            }
        }
                throw new Exception("the order doesn't exist");//if we were trying to update an inexisting order
        }
    }

