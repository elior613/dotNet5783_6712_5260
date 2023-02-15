using BlApi;
using BlImplementation;
using BO;
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

namespace PL.products
{
    /// <summary>
    /// Interaction logic for ProductForList.xaml
    /// </summary>
    public partial class ProductForList : Window
    {
        private IBL bl = new BL();
        public ProductForList()
        {
            InitializeComponent();
            productListView.ItemsSource=bl.Product.GetProductForLists();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Furniture));
        }

      

   
    }
}
