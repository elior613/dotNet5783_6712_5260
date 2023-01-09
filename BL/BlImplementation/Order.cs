using BlApi;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Order:IOrder
    {
        IDal Dal = new DalList();
    }
}
