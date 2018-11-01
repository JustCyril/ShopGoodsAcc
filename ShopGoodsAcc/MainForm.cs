using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ShopGoodsAcc.Data;

namespace ShopGoodsAcc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ShowAllProducts();
        }

        public void ShowAllProducts()
        {
            //очистка (?) dataGrifView, содержащего информацию о товарах
            //dGVProducts.Dispose();
            //это действие вообще убивает нафиг ataGridView, нужно поискать иные способы очистки (в цикле удалить все строки?)

            ProductDataRepository productData = new ProductDataRepository();
            List<Product> products = productData.GetAll();

            foreach (Product prod in products)
            {
                dGVProducts.Rows.Add(prod.name, prod.description, prod.amount, prod.shop.name);
            }

        }

        private void AddFormShowing(bool isChange)
        {
            AddChangeForm addChangeForm = new AddChangeForm();
            if (isChange)
            {
                addChangeForm.Text = "Изменение данных товара";
            }
            else
            {
                addChangeForm.Text = "Добавление товара";
            }
            addChangeForm.ShowDialog();
        }

        private void btnMainAdd_Click(object sender, EventArgs e)
        {
            
            AddFormShowing(false);
        }

        private void btnMainChange_Click(object sender, EventArgs e)
        {
            AddFormShowing(true);
        }

    }
}
