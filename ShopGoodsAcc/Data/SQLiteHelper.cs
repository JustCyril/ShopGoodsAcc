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
        //наверно эти три метода isFileExist(), CreateShopTable() и CreateProductTable() можно как-то переделать в нечто более красивое и унифицированное,
        //возможно даже и  GetDataFromDB() как-то в эту тусу подкинуть, но я пока плохо могу представить, как это красиво соединить.
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

        //т.к. этот процесс происходит как минимум несколько раз, меняется только sqlCmd, вывел это в отдельный метод.
        //sqlCmd задаётся вне метода, потом вызывается метод.
        public DataTable GetDataFromDB(string sqlStatement)
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
                        sqlCmd.CommandText = sqlStatement;
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCmd);

                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("DataTable пуста!");
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

        public DataTable GetAllShops()
        {
            return GetDataFromDB("SELECT * FROM Shops");
        }

        //пусть SQLiteHelper работает чисто с DataTable, преобразование в Shop проведем в репозитории. Или это тупо?
        //В принципе, есть DataRow, но не думаю, что 1 строка в таблице DataTable много места занимает, тем более унификация метода GetDataFromDB
        public DataTable GetShopForId(int id)
        {

            return GetDataFromDB(string.Format("SELECT * FROM Shops " +
                                               "WHERE id IN ({0})", id));
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
                        //прочитал, что insert через параметры позволяет избежать инъекций, дабы шаловливые юзеры не похерили БД
                        sqlCmd.CommandText = "INSERT INTO Shops (shop_name, shop_address) values (@shop_name, @shop_address)";
                        SQLiteParameter nameParam = new SQLiteParameter("@shop_name", shop_name);
                        sqlCmd.Parameters.Add(nameParam);
                        SQLiteParameter addressParam = new SQLiteParameter("@shop_address", shop_address);
                        sqlCmd.Parameters.Add(addressParam);

                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.Parameters.Clear();
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

        public bool UpdateShop(int id, string shop_name, string shop_address)
        {
            if (isFileExist()) //ну вдруг пользователь умудрится удалить этот файл, пока заполнял данные. Или это избыточно?
            {

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
                {
                    try
                    {
                        dbConnection.Open();
                        sqlCmd.Connection = dbConnection;
                        //прочитал, что insert через параметры позволяет избежать инъекций, дабы шаловливые юзеры не похерили БД
                        sqlCmd.CommandText = (string.Format("UPDATE Shops SET shop_name=@shop_name, shop_address=@shop_address WHERE id IN ({0})", id));
                        SQLiteParameter nameParam = new SQLiteParameter("@shop_name", shop_name);
                        sqlCmd.Parameters.Add(nameParam);
                        SQLiteParameter addressParam = new SQLiteParameter("@shop_address", shop_address);
                        sqlCmd.Parameters.Add(addressParam);

                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.Parameters.Clear();
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

        public bool DeleteShop(int id)
        {
            if (isFileExist()) //ну вдруг пользователь умудрится удалить этот файл, пока заполнял данные. Или это избыточно?
            {

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
                {
                    try
                    {
                        dbConnection.Open();
                        sqlCmd.Connection = dbConnection;
                        sqlCmd.CommandText = (string.Format("DELETE FROM Shops WHERE id IN ({0})", id));
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
