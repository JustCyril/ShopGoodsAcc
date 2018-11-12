using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ShopGoodsAcc.Data
{
    class SQLiteHelper
    {
        private string dbFileName = "ThisIsDataBase.sqlite";
        private SQLiteCommand sqlCmd = new SQLiteCommand();

        //если файла не существует, то его нужно создать, а в нем создать таблицы
        public bool isFileExist()
        {
            if (!File.Exists(dbFileName))
            {
                MessageBox.Show("Файл БД не существует и будет создан автоматически.");
                SQLiteConnection.CreateFile(dbFileName);
            }

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
            {
                dbConnection.Open();
                sqlCmd.Connection = dbConnection;
                CreateShopTable();
                CreateProductTable();
            }

            return true;
        }

        public void CreateShopTable()
        {
            sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Shops (" +
                                 "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                 "shop_name VARCHAR(100)," +
                                 "shop_address VARCHAR(200))";
            sqlCmd.ExecuteNonQuery();
        }

        public void CreateProductTable()
        {
            sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Products (" +
                                 "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                 "product_name VARCHAR(100)," +
                                 "product_discription VARCHAR(200)," +
                                 "amount INTEGER," +
                                 "shop_id INTEGER)";
            sqlCmd.ExecuteNonQuery();
        }

        public DataTable GetAllShops()
        {
            DataTable dataTable = new DataTable();

            if (isFileExist())
            {

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
                {
                    try
                    {
                        dbConnection.Open();
                        sqlCmd.Connection = dbConnection;
                        sqlCmd.CommandText = "SELECT * FROM Shops";
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCmd);

                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("База данных пуста");
                        }

                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }

            }

            return dataTable;
        }

        public bool AddShop(string shop_name, string shop_address)
        {
            if (isFileExist()) //ну вдруг пользователь умудрится удалить этот файл, пока заполнял данные. Или это избыточно?
            {

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
                {
                    try
                    {
                        dbConnection.Open();
                        sqlCmd.Connection = dbConnection;
                        sqlCmd.CommandText = "INSERT INTO Shops ('shop_name', 'shop_address') values ('" +
                                             shop_name + "' , '" +
                                             shop_address + "')";
                        sqlCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                        return false;
                    }
                }

            }

            else
            {
                return false;
            }

        }


    }
}
