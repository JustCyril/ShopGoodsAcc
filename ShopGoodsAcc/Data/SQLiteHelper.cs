using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace ShopGoodsAcc.Data
{
    class SQLiteHelper
    {
        //если файла не существует, то его нужно создать, а в нем создать таблицы
        //наверно эти три метода isFileExist(), CreateShopTable() и CreateProductTable() можно как-то переделать в нечто более красивое и унифицированное,
        //возможно даже и  GetDataFromDB() как-то в эту тусу подкинуть, но я пока плохо могу представить, как это красиво соединить.

        private bool isFileExist()
        {
            if (!File.Exists(SQLiteExecutor.dbFileName))
            {
                MessageBox.Show("Файл БД не существует и будет создан автоматически.");
                SQLiteConnection.CreateFile(SQLiteExecutor.dbFileName);
            }

            SQLiteExecutor.ExecuteAnyQuery(Querys.CreateShopTable());
            SQLiteExecutor.ExecuteAnyQuery(Querys.CreateProductTable());

            return true;
        }

        public DataTable GetAllShops()
        {
            return SQLiteExecutor.GetDataFromDB(Querys.GetAllShops());
        }

        //пусть SQLiteHelper работает чисто с DataTable, преобразование в Shop проведем в репозитории. Или это тупо?
        //В принципе, есть DataRow, но не думаю, что 1 строка в таблице DataTable много места занимает, тем более унификация метода GetDataFromDB
        public DataTable GetShopById(int id)
        {
            return SQLiteExecutor.GetDataFromDB(Querys.GetShopById(id));
        }

        public bool AddShop(string shop_name, string shop_address)
        {
            if (isFileExist()) //ну вдруг пользователь умудрится удалить этот файл, пока заполнял данные. Или это избыточно?
            {
                SQLiteExecutor.AddUpdate(Querys.AddShop(), shop_name, shop_address, 0);
                return true;
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
                SQLiteExecutor.AddUpdate(Querys.UpdateShopById(id), shop_name, shop_address, 0);
                return true;
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
                SQLiteExecutor.ExecuteAnyQuery(Querys.DeleteShopById(id));
                return true;
            }

            else
            {
                return false;
            }

        }


    }
}
