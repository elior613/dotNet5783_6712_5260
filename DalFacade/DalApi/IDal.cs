
namespace DalApi
{
    internal interface IDal:IOrder,IProduct,IOrderItem
    {
        IProduct Product { get; }
        IOrderItem OrderItem { get; }
        IOrder Order { get; }
    }
}
