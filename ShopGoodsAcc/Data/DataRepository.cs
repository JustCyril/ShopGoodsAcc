using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace ShopGoodsAcc.Data
{
    public class ProductDataRepository : IDataRepository<Product>
    {

        SQLiteHelper sqLiteHelper = new SQLiteHelper();

        public List<Product> GetAll()
        {
            if (sqLiteHelper.isFileExist())
            {

            }

            return;
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

            return;

        }

    }

    public class ShopDataRepository:IDataRepository<Shop>
    {
        public List<Shop> GetAll()
        {
            return;
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

            return;

        }


    }
}
