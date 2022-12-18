

namespace DalApi
{
    public interface ICrud<T>
    {
        public int Add(T t);
        public T Get(int id);
        public IEnumerable<T> GetAll();
        public void Delete(int id);
        public void Update(T t);
    }
}
