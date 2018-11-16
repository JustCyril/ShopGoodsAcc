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
        }

        public void FillShopsComboBox()
        {
            ShopDataRepository shopData = new ShopDataRepository();
            DataTable dataTable = shopData.GetAll();

            if (dataTable.Rows.Count > 0)
            {


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    //надеюсь сработает: в комбобокс выведем информацию без ID, обращаясь к конкретным ячейкам в таблице
                    comboBoxShopsAddChngProd.Items.Add(dataTable.Rows[i].Field <string>(1) + ", " + dataTable.Rows[i].Field<string>(2));
                    shop_ids.Add(dataTable.Rows[i].Field<int>(0));
                }

            }
        }

        public void SendDataFromTextBoxes()
        {
            ProductDataRepository productData = new ProductDataRepository();

            if (this.Text == "Добавление товара")
            {
                if (!(productData.Add()))
                {
                    MessageBox.Show("Ошибка репозитория (добавление)! Данные не сохранены.");
                }
            }
            else
            {
                if (!(productData.Update()))
                {
                    MessageBox.Show("Ошибка репозитория (изменение)! Данные не сохранены.");
                }
            }

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
                SendDataFromBoxes();
                this.Close();
            }

        }
    }
}
