using System;
using System.Windows.Forms;

namespace ShopGoodsAcc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
