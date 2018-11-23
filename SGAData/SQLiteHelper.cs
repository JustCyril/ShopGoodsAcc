using System.Data;
using System.Data.SQLite;
using System.IO;


namespace SGAData
{
    class SQLiteHelper
    {
        //если файла не существует, то его нужно создать, а в нем создать таблицы

        private bool isFileExist()
        {
            if (!File.Exists(SQLiteExecutor.dbFileName))
            {
                SQLiteConnection.CreateFile(SQLiteExecutor.dbFileName);
            }

            SQLiteExecutor.ExecuteAnyQuery(Querys.CreateShopTable());
            SQLiteExecutor.ExecuteAnyQuery(Querys.CreateProductTable());

            return true;
        }

        //--------------------------------------SHOPS SECTION----------------------------------------------------------------------------
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
                SQLiteExecutor.AddUpdate(Querys.AddShop(), shop_name, shop_address, 0, 0);
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
                SQLiteExecutor.AddUpdate(Querys.UpdateShopById(id), shop_name, shop_address, 0, 0);
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

        //--------------------------------------PRODUCTS SECTION----------------------------------------------------------------------------
        public DataTable GetAllProducts()
        {
            return SQLiteExecutor.GetDataFromDB(Querys.GetAllProducts());
        }

        public DataTable GetProductById(int id)
        {
            return SQLiteExecutor.GetDataFromDB(Querys.GetProductById(id));
        }

        public bool AddProduct(string name, string description, int amount, int shop_id)
        {
            if (isFileExist()) //ну вдруг пользователь умудрится удалить этот файл, пока заполнял данные. Или это избыточно?
            {
                SQLiteExecutor.AddUpdate(Querys.AddProduct(), name, description, amount, shop_id);
                return true;
            }

            else
            {
                return false;
            }

        }

        public bool UpdateProduct(int id, string name, string description, int amount, int shop_id)
        {
            if (isFileExist()) //ну вдруг пользователь умудрится удалить этот файл, пока заполнял данные. Или это избыточно?
            {
                SQLiteExecutor.AddUpdate(Querys.UpdateProductById(id), name, description, amount, shop_id);
                return true;
            }

            else
            {
                return false;
            }

        }

        public bool DeleteProduct(int id)
        {
            if (isFileExist()) //ну вдруг пользователь умудрится удалить этот файл, пока заполнял данные. Или это избыточно?
            {
                SQLiteExecutor.ExecuteAnyQuery(Querys.DeleteProductById(id));
                return true;
            }

            else
            {
                return false;
            }

        }

    }
}
