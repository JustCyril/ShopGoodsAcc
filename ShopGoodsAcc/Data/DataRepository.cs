using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopGoodsAcc.Data
{
    public class ProductDataRepository : IDataRepository<Product>
    {
        public List<Product> GetAll()
        {
            return DataGenerator.products;
        }

        public void Add()
        {

        }

        public void Change()
        {

        }

        public void Delete()
        {

        }

        public Product GetForId(int id)
        {
            //TODO:проверка на id<0;

            return DataGenerator.products.First(c => c.id == id);

        }

        public void Save() //сохранение всех изменений
        {

        }

    }

    public class ShopDataRepository:IDataRepository<Shop>;
    {
        public List<Shop> GetAll()
        {
            return DataGenerator.shops;
        }

        public void Add()
        {

        }

        public void Change()
        {

        }

        public void Delete()
        {

        }

        public Shop GetForId(int id)
        {
            //TODO:проверка на id<0;

            return DataGenerator.shops.First(c => c.id == id);

        }

        public void Save() //сохранение всех изменений
        {

        }


    }
}
