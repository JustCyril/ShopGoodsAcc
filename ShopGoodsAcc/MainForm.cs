using System;
using System.Windows.Forms;
using System.Data;
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
            dGVProducts.Rows.Clear();

            ProductDataRepository productData = new ProductDataRepository();
            DataTable dataTable = productData.GetAll();

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                    dGVProducts.Rows.Add(dataTable.Rows[i].ItemArray);
                //цикл использован потому, что лучше пока примера не нашел, а до этого было DataGridView.DataSource = productData.GetAll();
                //в результате чего в данном DataGridView добавлялись новые столбцы из предоставляемой DataTable
            }

        }

        //обновление формы работает по принципу:
        //"если уйти к последнему объекту, то RefreshForm(true), уйти наверх RefreshForm(false)
        //"если остаться на месте, то RefreshForm(индекс строки)"
        public void RefreshForm(bool goLast)
        {
            if (goLast)
            {
                ShowAllProducts();
                dGVProducts.CurrentCell = dGVProducts.Rows[dGVProducts.Rows.Count - 1].Cells[0];
            }
            else
            {
                ShowAllProducts();
            }

        }

        public void RefreshForm(int selectedRowIndex)
        {
            ShowAllProducts();
            dGVProducts.CurrentCell = dGVProducts.Rows[selectedRowIndex].Cells[0];
        }

        //решил использовать перегрузку для отображения дополнительной формы. При добавлении товара нам ничего не нужно передавать
        //а вот при изменении данных магазина, нам очень актуально передать данные в форму.

        private void AddFormShowing(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("ID товара содержит недопустимое значение"); //ну вдруг! хотя может можно и не делать, если ID автоинкрементный
            }
            else
            {
                AddChangeProdForm addChangeProdForm = new AddChangeProdForm();
                addChangeProdForm.Text = "Изменение данных товара";

                //скрыто вызывается метод получения данных для текст боксов, после чего уже демонстрируется сама форма
                //addChangeProdForm.GetDataForTextBoxes(id);

                addChangeProdForm.ShowDialog();
            }
        }

        private void AddFormShowing()
        {
            AddChangeProdForm addChangeProdForm = new AddChangeProdForm();
            addChangeProdForm.Text = "Добавление товара";
            addChangeProdForm.ShowDialog();
        }

        private void btnMainAdd_Click(object sender, EventArgs e)
        {
            AddFormShowing();
            RefreshForm(false);
        }

        private void btnMainChange_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dGVProducts.CurrentRow.Index; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (selectedRowIndex < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один магазин. Пожалуйста, выберите магазин для изменения данных.");
            }
            else
            {

                try
                {
                    //такой колхоз, потому что VS не принимает просто dGVShops.CurrentRow.Cells[0].Value, ссылаясь на то, что это объект в общем случае.
                    AddFormShowing(Convert.ToInt32(dGVProducts.CurrentRow.Cells[0].Value));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }

            }

            RefreshForm(selectedRowIndex);
        }

        private void btnMainShops_Click(object sender, EventArgs e)
        {
            ShopsForm shopsForm = new ShopsForm();
            shopsForm.ShowDialog();
            RefreshForm(false);
        }

        private void btnMainRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm(false);
        }

        private void btnMainDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dGVProducts.CurrentRow.Index; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (selectedRow < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один товар. Пожалуйста, выберите товар для удаления.");
            }
            else
            {

                if (MessageBox.Show("Вы уверены, что хотите удалить выделенный товар из БД?", "Удаление товара", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    ProductDataRepository productData = new ProductDataRepository();
                    try
                    {
                        //такой колхоз, потому что VS не принимает просто dGVShops.CurrentRow.Cells[0].Value, ссылаясь на то, что это объект в общем случае.
                        if (!(productData.Delete(Convert.ToInt32(dGVProducts.CurrentRow.Cells[0].Value))))
                        {
                            MessageBox.Show("Ошибка репозитория (удаление)! Товар не был удалён из БД.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }

            }

            if (selectedRow == (dGVProducts.Rows.Count - 1))
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
