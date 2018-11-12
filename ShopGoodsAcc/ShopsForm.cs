
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

            DataTable DataTable = shopData.GetAll();

            if (DataTable.Rows.Count > 0)
            {
                for (int i = 0; i < DataTable.Rows.Count; i++)
                    dGVShops.Rows.Add(DataTable.Rows[i].ItemArray);
                //цикл использован потому, что лучше пока примера не нашел, а до этого было DataGridView.DataSource = shopData.GetAll();
                //в результате чего в данном DataGridView добавлялись новые столбцы из предоставляемой DataTable
            }
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
            ShowAllShops(); //как только дочерняя форма закрылась (произошло добавление или нет), обновляем DataGridView (нововведение должно отразиться)
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
