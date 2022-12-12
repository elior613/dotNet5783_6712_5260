

namespace DalApi
{
    public interface ICrud<T>
    {
        T Add(T t);
        T Get(T t);
        IEnumerable<T> GetAll();
        void Delete(T t);
        void Update(T t);
    }
}
