using BlApi;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Product:IProduct
    {
        IDal Dal = new DalList();
    }
}
