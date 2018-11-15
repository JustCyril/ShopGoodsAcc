using System;
using System.Windows.Forms;
using ShopGoodsAcc.Data;

namespace ShopGoodsAcc
{
    public partial class AddChangeShopForm : Form
    {
        private int shop_id = 0; //мы его будем использовать для передачи данных в методе update, лучше пока не придумал

        public AddChangeShopForm()
        {
            InitializeComponent();
        }

        public void GetDataForTextBoxes(int id)
        {
            ShopDataRepository shopData = new ShopDataRepository();
            //надо ли чистить TextBox`ы на всякий случай, или они появляются чистыми?..
            Shop shop = shopData.GetById(id);
            shop_id = shop.id;

            tbNameAddChngShop.Text = shop.name;
            tbAddressAddChngShop.Text = shop.address;

        }

        public void SendDataFromTextBoxes()
        {
            ShopDataRepository shopData = new ShopDataRepository();

            if (this.Text == "Добавление магазина")
            {
                if (!(shopData.Add(tbNameAddChngShop.Text, tbAddressAddChngShop.Text)))
                {
                    MessageBox.Show("Ошибка добавления! Данные не сохранены.");
                }
            }
            else
            {
                if (!(shopData.Update(shop_id, tbNameAddChngShop.Text, tbAddressAddChngShop.Text)))
                {
                    MessageBox.Show("Ошибка добавления! Данные не сохранены.");
                }
            }

        }

        private void btnAddChangeShopCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddChangeShopOK_Click(object sender, EventArgs e)
        {
            if (tbNameAddChngShop.Text.Length == 0 || tbAddressAddChngShop.Text.Length == 0)
            {
                MessageBox.Show("Название магазина или адрес не может быть пустым! Данные не сохранены.");
                //TODO: проверка строк на какие-то необрабатываемые или системные символы (кавычки, наверно, нельзя, чтобы не сломать SQL-запрос?)
                //TODO: проверка на абсолютное совпадение, чтобы два раза не ввести один и тот же магаз?
            }
            else
            {
                SendDataFromTextBoxes();
            }

            this.Close();

        }
    }
}
