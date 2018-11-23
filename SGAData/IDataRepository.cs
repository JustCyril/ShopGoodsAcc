using System.Collections.Generic;

namespace SGAData
{
    public interface IDataRepository<T>
    {
        List<T> GetAll();
        bool Add(T t);
        bool Update(T t);
        bool Delete(int id);
        T GetById(int id);

    }
}
