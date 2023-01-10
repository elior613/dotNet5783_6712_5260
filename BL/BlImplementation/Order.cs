using BlApi;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Order: BlApi.IOrder
    {
        private IDal Dal = new DalList();
    }
    
}
