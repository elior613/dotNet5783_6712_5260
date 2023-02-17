using BlApi;
using BlImplementation;
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
using BlApi;
using BlImplementation;
using System.Collections.ObjectModel;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static BlApi.IBL? bl = BlApi.Factory.Get();

        ObservableCollection<BO.ProductForList?> list = new ObservableCollection<BO.ProductForList?>(bl.Product.GetProductForLists());
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new products.ProductForList(bl,list).Show();
        }

        private void AdminButton_Clik(object sender, RoutedEventArgs e)
        {

        }
        private void CostumerButton_Clik(object sender, RoutedEventArgs e)
        {

        }
        private void OrderTracking_Clik(object sender, RoutedEventArgs e)
        {

        }
    }
}
