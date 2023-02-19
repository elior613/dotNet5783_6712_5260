using BlApi;
using BO;
using PL.products;
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

namespace PL.Customer
{

    /// <summary>
    /// Interaction logic for CustomerCart.xaml
    /// </summary>
    public partial class CustomerCart : Window, INotifyPropertyChanged
    {
        BlApi.IBL? bl = BlApi.Factory.Get();


        //IEnumerable<OrderItem> listInCart;

        public BO.Cart? Cart
        {
            get { return (BO.Cart?)GetValue(cartProperty); }
            set { SetValue(cartProperty, value); }
        }
        public static readonly DependencyProperty cartProperty = DependencyProperty.Register(
        "Cart", typeof(BO.Cart), typeof(CustomerCart), new PropertyMetadata(default(BO.Cart)));

        private ObservableCollection<BO.OrderItem> listInCart;
        public ObservableCollection<BO.OrderItem> List
        {
            get => listInCart;
            set
            {
                listInCart = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("List"));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public CustomerCart(IBL bl, Cart cart)
        {
            this.bl = bl;
            Cart = cart;
            InitializeComponent();
            listInCart = new ObservableCollection<BO.OrderItem>(bl.Cart.getAllOrderItemInCart(cart));
            OrderItemListView.ItemsSource = listInCart;
        }

        private void ConfirmOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Cart.Confirmation(Cart, CustName.Text, CustEmail.Text, CustAdress.Text);
                MessageBox.Show("Order Confirmed");
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        private void Click_delete_from_Cart(object sender, RoutedEventArgs e)
        {
            BO.OrderItem item = (sender as Button)?.DataContext as BO.OrderItem;
            try
            {
                Cart = bl.Cart.Update(Cart, item.ProductID, 0);
                MessageBox.Show("deleted !");
                listInCart = new(from i in Cart.Items
                                 where i != null
                                 orderby i.ProductID
                                 select i);
                OrderItemListView.ItemsSource = listInCart;
                TotalPrice.Text = Cart.TotalPrice.ToString();

                if (Cart.TotalPrice == 0)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Click_Add_One_To_Cart(object sender, RoutedEventArgs e)
        {
            BO.OrderItem item = (sender as Button)?.DataContext as BO.OrderItem;

            try
            {
                Cart = bl.Cart.Update(Cart, item.ProductID, item.Amount + 1);
                listInCart = new(from i in Cart.Items
                                 where i != null
                                 orderby i.ProductID
                                 select i);
                OrderItemListView.ItemsSource = listInCart;
                TotalPrice.Text = Cart.TotalPrice.ToString();
                if (Cart.TotalPrice == 0)
                    this.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Click_Del_One_from_Cart(object sender, RoutedEventArgs e)
        {
            BO.OrderItem item = (sender as Button)?.DataContext as BO.OrderItem;
            try
            {
                Cart = bl.Cart.Update(Cart, item.ProductID, item.Amount - 1);
                listInCart = new(from i in Cart.Items
                                 where i != null
                                 orderby i.ProductID
                                 select i);
                OrderItemListView.ItemsSource = listInCart;
                TotalPrice.Text = Cart.TotalPrice.ToString();

                if (Cart.TotalPrice == 0)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
