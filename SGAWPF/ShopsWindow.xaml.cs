using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SGAData;

namespace SGAWPF
{
    /// <summary>
    /// Логика взаимодействия для ShopsWindow.xaml
    /// </summary>
    public partial class ShopsWindow : Window
    {
        public ShopsWindow()
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
                dgShops.SelectedIndex = dgShops.Items.Count - 1;
            }
            else
            {
                ShowAllShops();
            }

        }

        public void RefreshForm(int selectedRowIndex)
        {
            ShowAllShops();
            dgShops.SelectedIndex = selectedRowIndex;
        }

        public void ShowAllShops()
        {

            ShopDataRepository shopData = new ShopDataRepository();

            List<Shop> shops = shopData.GetAll();

            if (shops.Count > 0)
            {

                //не прокатило
                dgShops.ItemsSource = shops;

            }
            else
            {
                MessageBox.Show("Список магазинов пуст.");
            }
        }

        //решил использовать перегрузку для отображения дополнительной формы. При добавлении магазина нам ничего не нужно передавать
        //а вот при изменении данных магазина, нам очень актуально передать данные в форму.

        //Добавление нового магазина
        private void AddFormShowing()
        {
            AddUpdShopWindow addUpdShopWindow = new AddUpdShopWindow();
            addUpdShopWindow.Owner = this;
            addUpdShopWindow.ShowDialog();
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
                AddUpdShopWindow addUpdShopWindow = new AddUpdShopWindow();
                addUpdShopWindow.Owner = this;
                addUpdShopWindow.Title = "Изменение данных магазина";

                //скрыто вызывается метод получения данных для текст боксов, после чего уже демонстрируется сама форма
                addUpdShopWindow.GetDataForTextBoxes(id);

                addUpdShopWindow.ShowDialog();
            }

        }


        private void btnShopsAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUpdShopWindow addUpdShopWindow = new AddUpdShopWindow();
            addUpdShopWindow.Owner = this;
            addUpdShopWindow.ShowDialog();
            RefreshForm(true);
        }

        private void btnShopsChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedRowIndex = dgShops.SelectedIndex; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (selectedRowIndex < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один магазин. Пожалуйста, выберите магазин для изменения данных.");
            }
            else
            {

                try
                {
                    //такой колхоз, потому что VS не принимает просто dGVShops.CurrentRow.Cells[0].Value, ссылаясь на то, что это объект в общем случае.
                    //AddFormShowing(Convert.ToInt32(dgShops.Columns[0].GetCellContent(dgShops.Items[selectedRowIndex])));
                    //этот код выше не сработал, не могу понять, в чем именно ошибка, хотя по описанию вроде как поставил пересечение. Пойду другим путем.

                    Shop selectedShop = (Shop)dgShops.Items[selectedRowIndex];
                    AddFormShowing(selectedShop.id);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка, связанная с выделением в DataGrid: " + ex.Message);
                }

            }

            RefreshForm(selectedRowIndex);
        }

        private void btnShopsDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedRowIndex = dgShops.SelectedIndex; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (selectedRowIndex < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один магазин. Пожалуйста, выберите магазин для удаления.");
            }
            else
            {

                if (MessageBox.Show("Вы уверены, что хотите удалить выделенный магазин из БД?", "Удаление магазина", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ShopDataRepository shopData = new ShopDataRepository();
                    try
                    {
                        //почему тут такая жесть, см. метод btnShopsChange_Click, раздел try-catch
                        Shop selectedShop = (Shop)dgShops.Items[selectedRowIndex];
                        if (!(shopData.Delete(selectedShop.id)))
                        {
                            MessageBox.Show("Ошибка репозитория (удаление)! Магазин не был удален из БД.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления: " + ex.Message);
                    }
                }

            }

            if (selectedRowIndex == (dgShops.Items.Count - 1))
            {
                RefreshForm(true);
            }
            else
            {
                RefreshForm(selectedRowIndex);
            }
        }
    }
}
