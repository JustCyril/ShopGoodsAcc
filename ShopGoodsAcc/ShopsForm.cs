
using System;
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

        //решил использовать перегрузку для отображения дополнительной формы. При добавлении магазина нам ничего не нужно передавать
        //а вот при изменении данных магазина, нам очень актуально передать данные в форму.

        //Добавление нового магазина
        private void AddFormShowing()
        {
            AddChangeShopForm addChangeShopForm = new AddChangeShopForm();
            addChangeShopForm.Text = "Добавление магазина";
            
            addChangeShopForm.ShowDialog();

            ShowAllShops(); //как только дочерняя форма закрылась (произошло добавление или нет), обновляем DataGridView (нововведение должно отразиться)
        }

        //Изменение данных текущего магазина
        private void AddFormShowing(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("ID магазина содержит недопустимое значение"); //ну вдруг! хотя может можно и не делать, если ID автоинкрементный
            }
            else
            {
                AddChangeShopForm addChangeShopForm = new AddChangeShopForm();
                addChangeShopForm.Text = "Изменение данных магазина";

                //скрыто вызывается метод получения данных для текст боксов, после чего уже демонстрируется сама форма
                addChangeShopForm.GetDataForTextBoxes(id);

                addChangeShopForm.ShowDialog();
            }

            ShowAllShops(); //как только дочерняя форма закрылась (произошло добавление или нет), обновляем DataGridView (нововведение должно отразиться)
        }

        private void btnShopsAdd_Click(object sender, System.EventArgs e)
        {
            AddFormShowing();
        }

        private void btnShopsChange_Click(object sender, System.EventArgs e)
        {
            if (dGVShops.CurrentRow.Index < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один магазин. Пожалуйста, выберите магазин для изменения данных.");
            }
            else
            {
                try
                {
                    //такой колхоз, потому что VS не принимает просто dGVShops.CurrentRow.Cells[0].Value, ссылаясь на то, что это объект в общем случае.
                    AddFormShowing(Convert.ToInt32(dGVShops.CurrentRow.Cells[0].Value));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
                
            }
            
        }
    }
}
