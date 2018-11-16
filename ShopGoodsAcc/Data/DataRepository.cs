using System;
using System.Data;

namespace ShopGoodsAcc.Data
{
    public class ProductDataRepository : IDataRepository<Product>
    {

        SQLiteHelper sqLiteHelper = new SQLiteHelper();

        public DataTable GetAll()
        {
            return ;
        }

        public bool Add(string prod_name, string prod_descript, int amount, int shop_id)
        {
            if (sqLiteHelper.AddProduct(prod_name, prod_descript, amount, shop_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Change()
        {

        }

        public bool Delete(int id)
        {
            return ;
        }

        //    public Product GetById(int id)
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

        public bool Update(int id, string shop_name, string shop_address)
        {
            if (sqLiteHelper.UpdateShop(id, shop_name, shop_address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (sqLiteHelper.DeleteShop(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Shop GetById(int id)
        {
            DataTable dataTable = sqLiteHelper.GetShopById(id);

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
