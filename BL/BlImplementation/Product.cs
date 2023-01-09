using BlApi;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Product:BlApi.IProduct
    {
        IDal Dal = new DalList();
    }
}
