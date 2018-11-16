
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

        //обновление формы работает по принципу:
        //"если уйти к последнему объекту, то RefreshForm(true), уйти наверх RefreshForm(false)
        //"если остаться на месте, то RefreshForm(индекс строки)"
        public void RefreshForm(bool goLast)
        {
            if (goLast)
            {
                ShowAllShops();
                dGVShops.CurrentCell = dGVShops.Rows[dGVShops.Rows.Count - 1].Cells[0];
            }
            else
            {
                ShowAllShops();
            }

        }

        public void RefreshForm(int selectedRowIndex)
        {
            ShowAllShops();
            dGVShops.CurrentCell = dGVShops.Rows[selectedRowIndex].Cells[0];
        }

        public void ShowAllShops()
        {
            //очистка dataGridView, содержащего информацию о магазинах
            dGVShops.Rows.Clear();

            ShopDataRepository shopData = new ShopDataRepository();

            DataTable dataTable = shopData.GetAll();

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dGVShops.Rows.Add(dataTable.Rows[i].ItemArray);
                    //цикл использован потому, что лучше пока примера не нашел, а до этого было DataGridView.DataSource = shopData.GetAll();
                    //в результате чего в данном DataGridView добавлялись новые столбцы из предоставляемой DataTable
                }

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

        }

        private void btnShopsAdd_Click(object sender, EventArgs e)
        {
            AddFormShowing();
            RefreshForm(true);
        }

        private void btnShopsChange_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dGVShops.CurrentRow.Index; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (selectedRowIndex < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
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

            RefreshForm(selectedRowIndex);

        }

        private void btnShopsDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dGVShops.CurrentRow.Index; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (dGVShops.CurrentRow.Index < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один магазин. Пожалуйста, выберите магазин для удаления.");
            }
            else
            {

                if (MessageBox.Show("Вы уверены, что хотите удалить выделенный магазин из БД?", "Удаление магазина", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    ShopDataRepository shopData = new ShopDataRepository();
                    try
                    {
                        //такой колхоз, потому что VS не принимает просто dGVShops.CurrentRow.Cells[0].Value, ссылаясь на то, что это объект в общем случае.
                        if (!(shopData.Delete(Convert.ToInt32(dGVShops.CurrentRow.Cells[0].Value))))
                        {
                            MessageBox.Show("Ошибка репозитория (удаление)! Магазин не был удален из БД.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }

            }

            if (selectedRow == (dGVShops.Rows.Count - 1))
            {
                RefreshForm(true);
            }
            else
            {
                RefreshForm(selectedRow);
            }

        }
    }
}
