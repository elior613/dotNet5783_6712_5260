using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
using static BO.Exceptions;

namespace PL.products

{
    /// <summary>
    /// Interaction logic for ProductMainWindow.xaml
    /// </summary>
    /// 

    public partial class ProductMainWindow : Window
    {
        private IBL bl = new BL();
        int index;
        ObservableCollection<BO.ProductForList> list;
        bool _isValidInt = true;
        bool _isValidDouble = true;
        private int id { get; set; }
        private string name { get; set; }
        private double price { get; set; }
        private int instock { get; set; }
        private DO.Furniture category { get; set; }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ProductForList(bl,list).Show();
        }
       
    
      

        public BO.Product? product
        {
            get { return (BO.Product)GetValue(productProperty); }
            set { SetValue(productProperty, value); }
        }
        public static readonly DependencyProperty productProperty = DependencyProperty.Register(
        "product", typeof(BO.Product), typeof(ProductMainWindow), new PropertyMetadata(default(BO.Product)));

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            _isValidInt = int.TryParse(e.Text, out _);
            e.Handled = !_isValidInt;
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            _isValidDouble = double.TryParse(e.Text, out _);
            e.Handled = !_isValidDouble;
        }
        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            MessageBox.Show(catBox.SelectedItem.ToString());

        }


        /// <summary>
        /// constructor for add a new product window
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="list"></param>
        public ProductMainWindow(IBL bl, ObservableCollection<BO.ProductForList> list, BO.Product _product) // CONSTRUCTOR FOR ADD PRODUCT
        {
            product = new();
            this.bl = bl;
            this.list = list;
            InitializeComponent();
            product = _product; 
            IEnumerable<BO.ProductForList> products = bl.Product?.GetProductForLists();
            List<BO.ProductForList> productlist = products.ToList();
            product.ID = productlist.Count() + 100000;
            update_button.Visibility = Visibility.Collapsed;
            stock_text.PreviewTextInput += textBox1_PreviewTextInput;
            price_text.PreviewTextInput += textBox_PreviewTextInput;
            catBox.ItemsSource = Enum.GetValues(typeof(DO.Furniture));

        }

        /// <summary>
        /// ctor for update a product window 
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <param name="index"></param>
        public ProductMainWindow(IBL bl, int id, ObservableCollection<BO.ProductForList> list, int index, BO.Product _product) // CONSTRUCTOR FOR UPDATE PRODUCT 
        {
            product = new();
      
            this.bl = bl;
            this.list = list;
            InitializeComponent();
            this.index = index;
            catBox.ItemsSource = Enum.GetValues(typeof(DO.Furniture));
            confirm_button.Visibility = Visibility.Collapsed;
            product = _product;

        }
        /// <summary>
        /// cancel the task 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, RoutedEventArgs e) => this.Close(); // Cancel 

        /// <summary>
        /// add a new product function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Button_Click(object sender, RoutedEventArgs e) // Add 
        {
            if (!_isValidInt)
            {
                MessageBox.Show("Check the Stock");
                id_text.Focus();
                return;
            }
            else if (!_isValidDouble)
            {
                MessageBox.Show("Check the Price");
                id_text.Focus();
                return;
            }
            try
            {
                bl.Product.Add(product);

                MessageBox.Show($"Succesfully added !");
                list.Add(new BO.ProductForList
                {
                    Furniture = product.Furniture,
                    ID = product.ID,
                    Name = product.Name,
                    Price =product.Price,
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
        /// <summary>
        /// update product function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Button_Click(object sender, RoutedEventArgs e) // Update
        {
            if (!_isValidInt)
            {
                MessageBox.Show("Check the Stock");
                id_text.Focus();
                return;
            }
            else if (!_isValidDouble)
            {
                MessageBox.Show("Check the Price");
                id_text.Focus();
                return;
            }
            BO.Product updateProduct;
            try
            {
                int stockCount;
                if (!int.TryParse(stock_text.Text, out stockCount))
                {
                    throw new ErrorDetailsException("Stock not valid");
                }

                double price;
                if (!double.TryParse(price_text.Text, out price))
                {
                    throw new ErrorDetailsException("Price not valid");
                }

                bl.Product.Update(product);
                updateProduct = bl.Product.Get(product.ID);

                MessageBox.Show($"Succesfully updated");

                list[index] = new BO.ProductForList()
                {
                    Furniture = updateProduct.Furniture,
                    ID = updateProduct.ID,
                    Name = updateProduct.Name,
                    Price = updateProduct.Price 
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }


}