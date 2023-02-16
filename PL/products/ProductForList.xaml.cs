using BlApi;
using BlImplementation;
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace PL.products
{
    /// <summary>
    /// Interaction logic for ProductForList.xaml
    /// </summary>
    public partial class ProductForList : Window
    {
        private IBL bl = new BL();
        private ObservableCollection<BO.ProductForList?> list;
        public ObservableCollection<BO.ProductForList?> List
        {
            get => list;
            set
            {
                list = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("List"));
            }
        }
        public ProductForList(IBL bl, ObservableCollection<BO.ProductForList?> list)
        {
            InitializeComponent();
            productListView.ItemsSource=bl.Product.GetProductForLists();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Furniture));
            this.list = list;
            this.bl = bl;
        }
        
     

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if ((BO.Furniture)CategorySelector.SelectedItem == Furniture.all)
                productListView.ItemsSource = productListView.ItemsSource = bl.Product?.GetProductForLists();
            else productListView.ItemsSource = bl.Product.GetSomeProduct((BO.Furniture)CategorySelector.SelectedItem);
          
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Product product = new BO.Product();
                new ProductMainWindow(bl, list, product).Show(); // try to add
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Product_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           BO.Product _product = bl.Product.Get(((BO.ProductForList)productListView.SelectedItem).ID);
            new ProductMainWindow(bl, ((BO.ProductForList)productListView.SelectedItem).ID, list!, this.productListView.SelectedIndex, _product).Show();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
