using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGoodsAcc.Data
{
    static class Querys
    {
        public static string CreateShopTable()
        {
            string sqlStatement = "CREATE TABLE IF NOT EXISTS Shops (" +
                                  "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                  "shop_name VARCHAR(100)," +
                                  "shop_address VARCHAR(200))";

            return sqlStatement;
        }

        public static string CreateProductTable()
        {
            string sqlStatement = "CREATE TABLE IF NOT EXISTS Products (" +
                                  "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                  "product_name VARCHAR(100)," +
                                  "product_discription VARCHAR(200)," +
                                  "amount INTEGER," +
                                  "shop_id INTEGER)";
            return sqlStatement;
        }

        public static string GetAllShops()
        {
            string sqlStatement = "SELECT * FROM Shops";
            return sqlStatement;
        }


        public static string GetShopById(int id)
        {
            string sqlStatement = string.Format("SELECT * FROM Shops " +
                                                "WHERE id IN ({0})", id);
            return sqlStatement;
        }

        //чтобы правильно составить запрос, посмотри, как выглядит метод AddUpdate с параметрами (не факт, что это лучше, но там коммент написан, почему так :D)
        public static string AddShop()
        {
            string sqlStatement = "INSERT INTO Shops (shop_name, shop_address) values (@name, @description)";
            return sqlStatement;
        }

        public static string UpdateShopById(int id)
        {
            string sqlStatement = string.Format("UPDATE Shops SET shop_name=@name, shop_address=@description WHERE id IN ({0})", id);
            return sqlStatement;
        }

        public static string DeleteShopById(int id)
        {
            string sqlStatement = string.Format("DELETE FROM Shops WHERE id IN ({0})", id);
            return sqlStatement;
        }
    }
}
