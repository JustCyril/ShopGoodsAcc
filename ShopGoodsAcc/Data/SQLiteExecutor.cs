using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ShopGoodsAcc.Data
{
    public static class SQLiteExecutor
    {
        public static string dbFileName = "ThisIsDataBase.sqlite";

        public static DataTable GetDataFromDB(string sqlStatement)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
                {
                    dbConnection.Open();
                    using (SQLiteCommand sqlCmd = dbConnection.CreateCommand())
                    {
                        sqlCmd.CommandText = sqlStatement;
                        //может тут тоже using запихать? БОЛЬШЕ ЮЗИНГОВ БОГУ ЮЗИНГОВ!!!
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка получения данных из БД: " + ex.Message);
                dataTable.Clear();
            }

            //пусть тут и проверяет, я думаю, зачем проверку на пустую таблицу тащить далеко куда-то.
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("DataTable пуста! Проверьте правильность фильтров.");
            }

            return dataTable;
        }

        public static bool AddUpdate (string sqlStatement, string name, string description, int foreignKey)
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
                {
                    dbConnection.Open();
                    {
                        using (SQLiteCommand sqlCmd = dbConnection.CreateCommand())
                        {
                            sqlCmd.CommandText = sqlStatement;
                            //прочитал, что insert через параметры позволяет избежать инъекций, дабы шаловливые юзеры не похерили БД
                            SQLiteParameter nameParam = new SQLiteParameter("@name", name);
                            sqlCmd.Parameters.Add(nameParam);
                            SQLiteParameter descriptionParam = new SQLiteParameter("@description", description);
                            sqlCmd.Parameters.Add(descriptionParam);

                            if (foreignKey > 0)
                            {
                                SQLiteParameter foreignKeyParam = new SQLiteParameter("@foreignKey", foreignKey);
                                sqlCmd.Parameters.Add(foreignKeyParam);
                            }

                            sqlCmd.ExecuteNonQuery();
                            sqlCmd.Parameters.Clear();
                            return true;
                        }
                    }

                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка добавления в БД: " + ex.Message);
                return false;
            }

        }

        public static bool ExecuteAnyQuery(string sqlStatement)
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFileName + "; Version=3;"))
                {
                    dbConnection.Open();
                    {
                        using (SQLiteCommand sqlCmd = dbConnection.CreateCommand())
                        {
                            sqlCmd.CommandText = sqlStatement;
                            sqlCmd.ExecuteNonQuery();
                            return true;
                        }
                    }

                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка выполнения запроса к БД: " + ex.Message);
                return false;
            }

        }

    }
}
