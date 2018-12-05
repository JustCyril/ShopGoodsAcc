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
    /// Логика взаимодействия для AddUpdProdWindow.xaml
    /// </summary>
    public partial class AddUpdProdWindow : Window
    {
        public AddUpdProdWindow()
        {
            InitializeComponent();
            FillShopsComboBox();
        }

        private int prod_id = 0; //мы его будем использовать для передачи данных в методе update, лучше пока не придумал

        //т.к. у нас ID непоследовательны, мне кажется затруднительным восстановить ID из строчки comboBox, потому я просто составляю простейший
        //список айдишников, каждый из которых соответствует строке (несортированного) ComboBox. Возможно это не очень круто, но пока так.
        //дальше, как вариант, или писать парсер ID, или есть какая-то хитрость. Применение в методе FillShopsComboBox() и далее
        private List<int> shop_ids = new List<int>();

        public void FillShopsComboBox()
        {
            ShopDataRepository shopData = new ShopDataRepository();
            List<Shop> shops = shopData.GetAll();

            if (shops.Count > 0)
            {

                foreach (Shop shop in shops)
                {
                    //надеюсь сработает: в комбобокс выведем информацию без ID, обращаясь к конкретным ячейкам в таблице
                    cmbBoxShops.Items.Add(shop.name + ", " + shop.address);
                    shop_ids.Add(shop.id);
                }

            }
        }

        public void SendDataFromTextBoxes()
        {
            ProductDataRepository productData = new ProductDataRepository();
            Shop shop = new Shop(0, "", "");
            Product product = new Product(0, "", "", 0, shop);

            try
            {
                //тут неможко колхоза:
                //prod_id к нам приходит с родительской формы, а если нет, то нам и пофиг, ведь в методе Add я просто не буду даже его брать
                product.id = prod_id;
                product.name = tbProdName.Text;
                product.description = tbProdDescript.Text;
                product.amount = Convert.ToInt32(maskedtbAmount.Text.Replace("_",""));
                product.shop.id = shop_ids[cmbBoxShops.SelectedIndex];
                //и как видно, я данные магаза никуда не считываю, ибо не считаю целесообразным. Т.е. надо или тут SQL-запрос кидать, или ещё что-то, но зачем?
                //пользователь "видит" всё красиво, а "за кулисами" не вижу смысла утяжелять выполнение проги (в DB нам нужен только shop_id, "собирать" тут его
                //название и адрес, чтобы потом "разобрать" это в репозитории - не вижу смысла.
                //ну и да, try-catch потому, что вдруг что-то пойдет не так :D
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка изъятия данных из TextBox`ов: " + ex.Message);
            }

            if (this.Title == "Добавление товара")
            {
                if (!(productData.Add(product)))
                {
                    MessageBox.Show("Ошибка репозитория (добавление)! Данные не сохранены.");
                }
            }
            else
            {
                if (!(productData.Update(product)))
                {
                    MessageBox.Show("Ошибка репозитория (изменение)! Данные не сохранены.");
                }
            }

        }

        public void GetDataForTextBoxes(int id)
        {
            ProductDataRepository productData = new ProductDataRepository();
            Product product = productData.GetById(id);
            prod_id = id;


            tbProdName.Text = product.name;
            tbProdDescript.Text = product.description;
            maskedtbAmount.Text = product.amount.ToString();
            cmbBoxShops.SelectedIndex = shop_ids.IndexOf(product.shop.id);
        }

        private void btnProdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnProdOK_Click(object sender, RoutedEventArgs e)
        {
            if (tbProdName.Text.Length == 0 || tbProdDescript.Text.Length == 0)
            {
                MessageBox.Show("Название товара или его описание не может быть пустым!");

            }
            else
            {
                //TODO: проверка строк на какие-то необрабатываемые или системные символы
                //TODO: проверка на абсолютное совпадение, чтобы два раза не ввести один и тот же магаз?
                SendDataFromTextBoxes();
                this.Close();
            }
        }
    }
}
