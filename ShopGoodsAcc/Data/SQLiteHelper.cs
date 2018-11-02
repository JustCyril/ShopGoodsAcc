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
        public string dbFileName = "ThisIsDataBase";
        public SQLiteConnection dbConnection = new SQLiteConnection();
        public SQLiteCommand sqlCmd = new SQLiteCommand();

        public bool isFileExist()
        {
            if (!File.Exists(dbFileName))
            {
                MessageBox.Show("Файл БД не существует и будет создан автоматически.");
                SQLiteConnection.CreateFile(dbFileName);
                return true; //ну типа на будущее, если пользователь будет свой адрес вводить...
            }
            else
            {
                return true;
            }
        }

        public void OpenConnectToDB()
        {
            dbConnection = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;"); //я понятия не имею, почему Version=3, так было у автора статьи
            dbConnection.Open();
            sqlCmd.Connection = dbConnection;
        }

        public void CreateDBTable()
        {
            //как припаять 2 таблицы? как отображать shop в таблице product?
            sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Catalog (id INTEGER PRIMARY KEY AUTOINCREMENT, product_name TEXT, product_discription TEXT, amount INTEGER, shop TEXT)";
            sqlCmd.ExecuteNonQuery();
        }
    }
}
