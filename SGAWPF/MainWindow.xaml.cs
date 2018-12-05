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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SGAData;

namespace SGAWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowAllProducts();
        }

        public void ShowAllProducts()
        {

            ProductDataRepository productData = new ProductDataRepository();

            try
            {
                List<Product> products = productData.GetAll();
                if (products.Count > 0)
                {
                    dgProducts.ItemsSource = products;
                }
                else
                {
                    MessageBox.Show("Список товаров пуст.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления данных в DataGrid" + ex.Message);
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
                dgProducts.SelectedIndex = dgProducts.Items.Count - 1;
                dgProducts.ScrollIntoView(dgProducts.SelectedIndex);
            }
            else
            {
                ShowAllProducts();
            }

        }

        public void RefreshForm(int selectedRowIndex)
        {
            ShowAllProducts();
            dgProducts.SelectedIndex = selectedRowIndex;
            dgProducts.ScrollIntoView(dgProducts.SelectedIndex);
        }

        //решил использовать перегрузку для отображения дополнительной формы. При добавлении товара нам ничего не нужно передавать
        //а вот при изменении данных магазина, нам очень актуально передать данные в форму.

        private void AddUpdWindowShowing(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("ID товара содержит недопустимое значение"); //ну вдруг! хотя может можно и не делать, если ID автоинкрементный
            }
            else
            {
                AddUpdProdWindow addUpdProdWindow = new AddUpdProdWindow();
                addUpdProdWindow.Owner = this;
                addUpdProdWindow.Title = "Изменение данных товара";

                //скрыто вызывается метод получения данных для текст боксов, после чего уже демонстрируется сама форма

                addUpdProdWindow.GetDataForTextBoxes(id);
                addUpdProdWindow.ShowDialog();
            }
        }

        private void AddUpdWindowShowing()
        {

            AddUpdProdWindow addUpdProdWindow = new AddUpdProdWindow();
            addUpdProdWindow.Owner = this;
            addUpdProdWindow.ShowDialog();

        }

        private void btnMainShops_Click(object sender, RoutedEventArgs e)
        {
            ShopsWindow shopsWindow = new ShopsWindow();
            
            shopsWindow.Owner = this; //для меня это было неочевидно, и я долго задавался вопросом, какого фига дочернее окно не открывается внутри родительского
            shopsWindow.ShowDialog();
        }

        private void btnMainAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUpdWindowShowing();
            RefreshForm(true);
        }

        private void btnMainChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedRowIndex = dgProducts.SelectedIndex; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (selectedRowIndex < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один товар. Пожалуйста, выберите товар для изменения данных.");
            }
            else
            {

                try
                {

                    //такой колхоз, потому что VS не принимает просто выражение без "конверта", ссылаясь на то, что это объект в общем случае.
                    //AddUpdWindowShowing(Convert.ToInt32(dgProducts.Columns[0].GetCellContent(dgProducts.Items[selectedRowIndex])));
                    //попытки найти аналогию кода, работавшего в WinForms не привели к успеху, потому пошел другим путем

                    Product selectedProduct = (Product)dgProducts.Items[selectedRowIndex];
                    AddUpdWindowShowing(selectedProduct.id);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка, связанная с выделением в DataGrid: " + ex.Message);
                }

            }

            RefreshForm(selectedRowIndex);


        }

        private void btnMainRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.ItemsSource = null;
            dgProducts.Items.Clear();
            RefreshForm(false);
        }

        private void btnMainDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedRowIndex = dgProducts.SelectedIndex; //будет использована позднее, чтобы вернуться на ту строчку, которую выбрал пользователь

            if (selectedRowIndex < 0) //а надо ли оно вообще? Судя по запуску, прога всегда выделяет ячейку 0,0. Ну да ладно, путь будет пока.
            {
                MessageBox.Show("Не выбран ни один товар. Пожалуйста, выберите товар для удаления.");
            }
            else
            {

                if (MessageBox.Show("Вы уверены, что хотите удалить выделенный товар из БД?", "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ProductDataRepository productData = new ProductDataRepository();
                    try
                    {
                        Product selectedProduct = (Product)dgProducts.Items[selectedRowIndex];
                        if (!(productData.Delete(selectedProduct.id)))
                        {
                            MessageBox.Show("Ошибка репозитория (удаление)! Товар не был удалён из БД.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления: " + ex.Message);
                    }
                }

            }

            if (selectedRowIndex == (dgProducts.Items.Count - 1))
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
