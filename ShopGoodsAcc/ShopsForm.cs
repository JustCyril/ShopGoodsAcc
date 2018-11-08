
using System.Data;
using System.Windows.Forms;
using ShopGoodsAcc.Data;

namespace ShopGoodsAcc
{
    public partial class ShopsForm : Form
    {
        public ShopsForm()
        {
            InitializeComponent();
            ShowAllShops();
        }

        public void ShowAllShops()
        {
            //очистка dataGridView, содержащего информацию о магазинах
            dGVShops.Rows.Clear();

            ShopDataRepository shopData = new ShopDataRepository();

            dGVShops.DataSource = shopData.GetAll();
        }

        private void AddFormShowing(bool isChange)
        {
            AddChangeShopForm addChangeShopForm = new AddChangeShopForm();
            if (isChange)
            {
                addChangeShopForm.Text = "Изменение данных магазина";
            }
            else
            {
                addChangeShopForm.Text = "Добавление магазина";
            }
            addChangeShopForm.ShowDialog();
        }

        private void btnShopsAdd_Click(object sender, System.EventArgs e)
        {
            AddFormShowing(false);
        }

        private void btnShopsChange_Click(object sender, System.EventArgs e)
        {
            AddFormShowing(true);
        }
    }
}
