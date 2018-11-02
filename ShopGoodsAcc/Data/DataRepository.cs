using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace ShopGoodsAcc.Data
{
    public class ProductDataRepository : IDataRepository<Product>
    {
        ////если не создавал экземпляр DataGenerator, то в Main при вызове products = productData.GetAll(); параметр products был null.
        ////надо создавать или я что-то сделал неправильно?
        //DataGenerator data = new DataGenerator();

        SQLiteHelper sqLiteHelper = new SQLiteHelper();

        public List<Product> GetAll()
        {
            if (sqLiteHelper.isFileExist())
            {

            }

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

            return DataGenerator.products.Where(s => s.id == id).FirstOrDefault();

        }

    }

    public class ShopDataRepository:IDataRepository<Shop>
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


    }
}
