﻿using System;
using System.Windows.Forms;
using SGAData;

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

            Shop shop = new Shop(0, tbNameAddChngShop.Text, tbAddressAddChngShop.Text);

            if (this.Text == "Добавление магазина")
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

        private void btnAddChangeShopCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddChangeShopOK_Click(object sender, EventArgs e)
        {
            if (tbNameAddChngShop.Text.Length == 0 || tbAddressAddChngShop.Text.Length == 0)
            {
                MessageBox.Show("Название магазина или адрес не может быть пустым!");
                //TODO: проверка строк на какие-то необрабатываемые или системные символы (кавычки, наверно, нельзя, чтобы не сломать SQL-запрос?)
                //TODO: проверка на абсолютное совпадение, чтобы два раза не ввести одно и то же?
            }
            else
            {
                SendDataFromTextBoxes();
                this.Close();
            }

        }
    }
}
