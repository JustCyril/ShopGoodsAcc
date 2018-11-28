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
        }

        private void btnShopsAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUpdShopWindow addUpdShopWindow = new AddUpdShopWindow();
            addUpdShopWindow.Owner = this;
            addUpdShopWindow.ShowDialog();
        }
    }
}
