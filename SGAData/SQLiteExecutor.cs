using System;
using System.Data;
using System.Data.SQLite;

namespace SGAData
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
                dataTable.Clear();
                //я хз, будут ли оно пробрасываться нормально, но пусть будет
                throw new Exception ("Ошибка получения данных из БД: " + ex.Message);
            }

            return dataTable;
        }

        public static bool AddUpdate (string sqlStatement, string name, string description, int amount, int shop_id)
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

                            //условием ниже мы определяем, работаем мы с добавлением/изменением данных магазина или же товара. У товара есть fk в виде shop_id,
                            //а у магазина нет никаких fk. Таким колхозом пока и унифицируем метод для обоих сущностей Product и Shop
                            if (shop_id > 0)
                            {
                                SQLiteParameter amountParam = new SQLiteParameter("@amount", amount);
                                sqlCmd.Parameters.Add(amountParam);

                                SQLiteParameter shop_idParam = new SQLiteParameter("@shop_id", shop_id);
                                sqlCmd.Parameters.Add(shop_idParam);
                            }

                            sqlCmd.ExecuteNonQuery();
                            sqlCmd.Parameters.Clear(); //кстати, наверно, clear() можно и не делать, если мы используем using, он же все равно убивает команду.
                            return true;
                        }
                    }

                }
            }
            catch (SQLiteException)
            {
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
            catch (SQLiteException)
            {
                return false;
            }

        }

    }
}
