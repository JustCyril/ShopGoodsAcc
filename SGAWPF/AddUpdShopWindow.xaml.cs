using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SGAData;

namespace SGAWPF
{
    /// <summary>
    /// Логика взаимодействия для AddUpdShopWindow.xaml
    /// </summary>
    public partial class AddUpdShopWindow : Window
    {
        public AddUpdShopWindow()
        {
            InitializeComponent();
        }

        private int shop_id = 0; //мы его будем использовать для передачи данных в методе update, лучше пока не придумал

        public void GetDataForTextBoxes(int id)
        {
            ShopDataRepository shopData = new ShopDataRepository();
            //надо ли чистить TextBox`ы на всякий случай, или они появляются чистыми?..
            Shop shop = shopData.GetById(id);
            shop_id = shop.id;

            tbShopName.Text = shop.name;
            tbShopAddress.Text = shop.address;

        }

        public void SendDataFromTextBoxes()
        {
            ShopDataRepository shopData = new ShopDataRepository();

            Shop shop = new Shop(0, tbShopName.Text, tbShopAddress.Text);

            if (this.Title == "Добавление магазина")
            {
                if (!(shopData.Add(shop)))
                {
                    MessageBox.Show("Ошибка репозитория (добавление)! Данные не сохранены.");
                }
            }
            else
            {
                shop.id = shop_id;
                if (!(shopData.Update(shop)))
                {
                    MessageBox.Show("Ошибка репозитория (изменение)! Данные не сохранены.");
                }
            }

        }

        private void btnShopCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnShopOK_Click(object sender, RoutedEventArgs e)
        {
            if (tbShopName.Text.Length == 0 || tbShopAddress.Text.Length == 0)
            {
                MessageBox.Show("Название магазина или адрес не может быть пустым!");

            }
            else
            {
                //TODO: проверка строк на какие-то необрабатываемые или системные символы (кавычки, наверно, нельзя, чтобы не сломать SQL-запрос?)
                //TODO: проверка на абсолютное совпадение, чтобы два раза не ввести одно и то же?
                SendDataFromTextBoxes();
                this.Close();
            }
        }
    }
}
