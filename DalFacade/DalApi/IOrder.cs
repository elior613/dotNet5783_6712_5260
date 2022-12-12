

using DO;
namespace DalApi
{
    public interface IOrder:ICrud<Order>
    {
        public IEnumerable<string> GetDetails(int IDnum);
    }
}
