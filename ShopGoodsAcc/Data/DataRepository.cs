using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ShopGoodsAcc.Data
{
    public class ProductDataRepository : IDataRepository<Product>
    {

        SQLiteHelper sqLiteHelper = new SQLiteHelper();

        //    public List<Product> GetAll()
        //    {
        //        if (sqLiteHelper.isFileExist())
        //        {

        //        }

        //        return;
        //    }

        //    public void Add()
        //    {

        //    }

        //    public void Change()
        //    {

        //    }

        //    public void Delete()
        //    {

        //    }

        //    public Product GetForId(int id)
        //    {

        //        return;

        //    }

    }

    public class ShopDataRepository : IDataRepository<Shop>
    {
        SQLiteHelper sqLiteHelper = new SQLiteHelper();

        public DataTable GetAll()
        {
            return sqLiteHelper.GetAllShops();
        }

        public bool Add(string shop_name, string shop_address)
        {
            if (sqLiteHelper.AddShop(shop_name, shop_address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public void Change()
        //{

        //}

        //public void Delete()
        //{

        //}

        public Shop GetForId(int id)
        {
            DataTable dataTable = sqLiteHelper.GetShopForId(id);

            //сначала у меня был Shop shop = new Shop(Convert.ToInt32(dataTable.Rows[0][0].ToString()), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString());
            //но я решил, что это херово читается;

            Shop shop = new Shop(0, "", "");
            shop.id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
            shop.name = dataTable.Rows[0][1].ToString();
            shop.address = dataTable.Rows[0][2].ToString();

            return shop;

        }


    }

}
