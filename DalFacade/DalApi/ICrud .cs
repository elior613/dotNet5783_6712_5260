

namespace DalApi
{
    public interface ICrud<T> where T : struct
    {
        public int Add(T t);
        public T Get(int id);
        T? Get(Func<T?, bool>? filter);
        public IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
        public void Delete(int id);
        public void Update(T? t);
    }
}
