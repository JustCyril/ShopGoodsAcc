using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ShopGoodsAcc.Data
{
    class SQLiteHelper
    {
        private string dbFileName = "ThisIsDataBase.sqlite";
        private SQLiteConnection dbConnection = new SQLiteConnection();
        private SQLiteCommand sqlCmd = new SQLiteCommand();

        //если файла не существует, то его нужно создать, а в нем создать таблицы
        public bool isFileExist()
        {
            if (!File.Exists(dbFileName))
            {
                MessageBox.Show("Файл БД не существует и будет создан автоматически.");
                SQLiteConnection.CreateFile(dbFileName);
                CreateShopTable();
                CreateProductTable();
                return true; //ну типа на будущее, если пользователь будет свой адрес вводить...
            }
            else
            {
                return true;
            }
        }

        public void CreateShopTable()
        {
            sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Shops (" +
                                 "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                 "shop_name VARCHAR(100)," +
                                 "shop_adress VARCHAR(MAX))";
            sqlCmd.ExecuteNonQuery();
        }

        public void CreateProductTable()
        {
            sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Products (" +
                                 "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                 "product_name VARCHAR(100)," +
                                 "product_discription VARCHAR(MAX)," +
                                 "amount INTEGER," +
                                 "shop_id INTEGER)";
            sqlCmd.ExecuteNonQuery();
        }

        public void OpenConnectToDB()
        {
            try
            {
                dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"); //я понятия не имею, почему Version=3, так было у автора статьи
                dbConnection.Open();                                                               //возможно это использование стандарта SQL3 (SQL:1999 и его наследника SQL:2003)
                sqlCmd.Connection = dbConnection;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }

        }

        public void GetAllFromTable()
        {

        }


    }
}
