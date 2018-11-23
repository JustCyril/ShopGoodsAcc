using System;
using System.Collections.Generic;
using System.Data;

namespace SGAData
{
    public class ProductDataRepository : IDataRepository<Product>
    {

        SQLiteHelper sqLiteHelper = new SQLiteHelper();

        public List<Product> GetAll()
        {
            DataTable dataTable = sqLiteHelper.GetAllProducts();
            List<Product> products = new List<Product>();

            if (dataTable.Rows.Count > 0)
            {

                ShopDataRepository shopData = new ShopDataRepository();

                foreach (DataRow dr in dataTable.Rows)
                {
                    Shop shop = new Shop(0, "", "");
                    Product product = new Product(0, "", "", 0, shop);

                    product.id = Convert.ToInt32(dr[0].ToString());
                    product.name = dr[1].ToString();
                    product.description = dr[2].ToString();
                    product.amount = Convert.ToInt32(dr[3].ToString());
                    product.shop = shopData.GetById(Convert.ToInt32(dr[4].ToString()));

                    products.Add(product);
                }
            }

            return products;
        }

        public bool Add(Product product)
        {
            if (sqLiteHelper.AddProduct(product.name, product.description, product.amount, product.shop.id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Product product)
        {
            if (sqLiteHelper.UpdateProduct(product.id, product.name, product.description, product.amount, product.shop.id))
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
            if (sqLiteHelper.DeleteProduct(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product GetById(int id)
        {

            DataTable dataTable = sqLiteHelper.GetProductById(id);

            //не знаю, насколько это красиво выглядит, но мне кажется, более читабельно, чем если все эти преобразования скинуть в одну строку конструктора
            Shop shop = new Shop(0, "", "");
            Product product = new Product(0, "", "", 0, shop);

            product.id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
            product.name = dataTable.Rows[0][1].ToString();
            product.description = dataTable.Rows[0][2].ToString();
            product.amount = Convert.ToInt32(dataTable.Rows[0][3].ToString());

            ShopDataRepository shopData = new ShopDataRepository();
            product.shop = shopData.GetById(Convert.ToInt32(dataTable.Rows[0][4].ToString()));

            return product;

        }

    }

    public class ShopDataRepository : IDataRepository<Shop>
    {
        SQLiteHelper sqLiteHelper = new SQLiteHelper();

        public List<Shop> GetAll()
        {
            DataTable dataTable = sqLiteHelper.GetAllShops();
            List<Shop> shops = new List<Shop>();

            if (dataTable.Rows.Count > 0)
            {

                foreach (DataRow dr in dataTable.Rows)
                {
                    Shop shop = new Shop(0, "", "");
                    shop.id = Convert.ToInt32(dr[0].ToString());
                    shop.name = dr[1].ToString();
                    shop.address = dr[2].ToString();
                    shops.Add(shop);
                }
            }

            return shops;
        }

        public bool Add(Shop shop)
        {
            if (sqLiteHelper.AddShop(shop.name, shop.address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Shop shop)
        {
            if (sqLiteHelper.UpdateShop(shop.id, shop.name, shop.address))
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
            try
            {
                shop.id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                shop.name = dataTable.Rows[0][1].ToString();
                shop.address = dataTable.Rows[0][2].ToString();
            }
            catch (Exception)
            {
                shop.id = 0;
                shop.name = "Магазин был удалён.";
                shop.address = "Исправьте это, пожалуйста.";
            }



            return shop;

        }


    }

}
