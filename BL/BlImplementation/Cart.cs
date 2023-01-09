using BlApi;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Cart:ICart
    {
        IDal Dal = new DalList();
    }
}
