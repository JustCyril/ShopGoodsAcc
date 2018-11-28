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
            dgProducts.Items.Clear();

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

                //addUpdProdWindow.GetDataForTextBoxes(id);
                addUpdProdWindow.ShowDialog();
            }
        }

        private void AddFormShowing()
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
            AddFormShowing();
        }
    }
}
