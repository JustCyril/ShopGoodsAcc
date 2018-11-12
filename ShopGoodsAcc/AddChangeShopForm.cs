using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                string shop_name = tbNameAddChngShop.Text;
                string shop_adress = tbAddressAddChngShop.Text;

                ShopDataRepository shopData = new ShopDataRepository();
                //на одной форме может быть как добавление, так и изменение существующих данных,
                //узнаём это из заголовка формы (т.к. при её show мы меняем заголовок, передавая параметр)

                if (this.Text == "Добавление магазина")
                {
                    if (!(shopData.Add(shop_name, shop_adress)))
                    {
                        MessageBox.Show("Ошибка добавления! Данные не сохранены.");
                    }
                }
                else
                {
                    //shopData.Change(shop_name, shop_adress);
                }

            }

            this.Close();

        }
    }
}
