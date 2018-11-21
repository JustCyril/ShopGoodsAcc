using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ShopGoodsAcc.Data;

namespace ShopGoodsAcc
{
    public partial class AddChangeProdForm : Form
    {
        private int prod_id = 0; //мы его будем использовать для передачи данных в методе update, лучше пока не придумал

        //т.к. у нас ID непоследовательны, мне кажется затруднительным восстановить ID из строчки comboBox, потому я просто составляю простейший
        //список айдишников, каждый из которых соответствует строке (несортированного) ComboBox. Возможно это не очень круто, но пока так.
        //дальше, как вариант, или писать парсер ID, или есть какая-то хитрость. Применение в методе FillShopsComboBox() и далее
        private List<int> shop_ids = new List<int>();

        public AddChangeProdForm()
        {
            InitializeComponent();
            FillShopsComboBox();
        }

        public void FillShopsComboBox()
        {
            ShopDataRepository shopData = new ShopDataRepository();
            List<Shop> shops = shopData.GetAll();

            if (shops.Count > 0)
            {

                foreach (Shop shop in shops)
                {
                    //надеюсь сработает: в комбобокс выведем информацию без ID, обращаясь к конкретным ячейкам в таблице
                    comboBoxShopsAddChngProd.Items.Add(shop.name + ", " + shop.address);
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
                product.name = tbProdNameAddСhngProd.Text;
                product.description = tbProdDescriptAddCnhgProd.Text;
                product.amount = Convert.ToInt32(mskdTBAmountAddChngProd.Text);
                product.shop.id = shop_ids[comboBoxShopsAddChngProd.SelectedIndex];
                //и как видно, я данные магаза никуда не считываю, ибо не считаю целесообразным. Т.е. надо или тут SQL-запрос кидать, или ещё что-то, но зачем?
                //пользователь "видит" всё красиво, а "за кулисами" не вижу смысла утяжелять выполнение проги (в DB нам нужен только shop_id, "собирать" тут его
                //название и адрес, чтобы потом "разобрать" это в репозитории - не вижу смысла.
                //ну и да, try-catch потому, что вдруг что-то пойдет не так :D
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка изъятия данных из TextBox`ов: " +ex.Message);
            }

            if (this.Text == "Добавление товара")
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


            tbProdNameAddСhngProd.Text = product.name;
            tbProdDescriptAddCnhgProd.Text = product.description;
            mskdTBAmountAddChngProd.Text = product.amount.ToString();
            comboBoxShopsAddChngProd.SelectedIndex = shop_ids.IndexOf(product.shop.id);
        }

        private void btnCancelAddChngProd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOKAddChngProd_Click(object sender, EventArgs e)
        {
            
            if (tbProdNameAddСhngProd.Text.Length == 0 || tbProdDescriptAddCnhgProd.Text.Length == 0)
            {
                MessageBox.Show("Название товара или его описание не может быть пустым!");
                //TODO: проверка строк на какие-то необрабатываемые или системные символы (кавычки, наверно, нельзя, чтобы не сломать SQL-запрос?)
                //TODO: проверка на абсолютное совпадение, чтобы два раза не ввести один и тот же магаз?
            }
            else
            {
                SendDataFromTextBoxes();
                this.Close();
            }

        }
    }
}
