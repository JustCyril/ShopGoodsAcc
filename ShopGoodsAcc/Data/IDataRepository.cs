using System;
using System.Collections.Generic;

namespace ShopGoodsAcc.Data
{
    public interface IDataRepository<T>
    {
        List<T> GetAll();
        //void Add(T obj);
        //void Change(T obj);
        //void Delete(T obj);
        T GetForId(int id);

    }
}
