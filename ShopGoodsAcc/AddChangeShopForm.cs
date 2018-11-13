using System;
using System.Windows.Forms;
using ShopGoodsAcc.Data;

namespace ShopGoodsAcc
{
    public partial class AddChangeShopForm : Form
    {

        public AddChangeShopForm()
        {
            InitializeComponent();
        }

        public void GetDataForTextBoxes(int id)
        {
            ShopDataRepository shopData = new ShopDataRepository();
            //надо ли чистить TextBox`ы на всякий случай, или они появляются чистыми?..
            Shop shop = shopData.GetForId(id);

            tbNameAddChngShop.Text = shop.name;
            tbAddressAddChngShop.Text = shop.address;

        }

        public void SendDataFromTextBoxes()
        {
            ShopDataRepository shopData = new ShopDataRepository();

            if (!(shopData.Add(tbNameAddChngShop.Text, tbAddressAddChngShop.Text)))
            {
                MessageBox.Show("Ошибка добавления! Данные не сохранены.");
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
                this.Close();
                //TODO: придумать, как "зациклить" это, пока пользователь не введет данные.
                //TODO: проверка строк на какие-то необрабатываемые или системные символы (кавычки, наверно, нельзя, чтобы не сломать SQL-запрос?)
            }
            else
            {
                SendDataFromTextBoxes();
            }

            this.Close();

        }
    }
}
