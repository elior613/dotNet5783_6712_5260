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
using BlApi;
using BlImplementation;
namespace PL.products

{
    /// <summary>
    /// Interaction logic for ProductMainWindow.xaml
    /// </summary>
    /// 
  
    public partial class ProductMainWindow : Window
    {
        private IBL bl = new BL();
        public ProductMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ProductForList().Show();
        }
    }
}
