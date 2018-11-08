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
            //очистка dataGridView, содержащего информацию о товарах
            dGVProducts.Rows.Clear();

            //ProductDataRepository productData = new ProductDataRepository();
            //List<Product> products = productData.GetAll();

            //foreach (Product prod in products)
            //{
            //    dGVProducts.Rows.Add(prod.name, prod.description, prod.amount, prod.shop.name);
            //}

        }

        private void AddFormShowing(bool isChange)
        {
            AddChangeProdForm addChangeProdForm = new AddChangeProdForm();
            if (isChange)
            {
                addChangeProdForm.Text = "Изменение данных товара";
            }
            else
            {
                addChangeProdForm.Text = "Добавление товара";
            }
            addChangeProdForm.ShowDialog();
        }

        private void btnMainAdd_Click(object sender, EventArgs e)
        {
            
            AddFormShowing(false);
        }

        private void btnMainChange_Click(object sender, EventArgs e)
        {
            AddFormShowing(true);
        }

        private void btnMainShops_Click(object sender, EventArgs e)
        {
            ShopsForm shopsForm = new ShopsForm();
            shopsForm.ShowDialog();
        }
    }
}
