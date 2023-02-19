using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace PL.Customer;

/// <summary>
/// Interaction logic for ProductListCatalogWindow.xaml
/// </summary>
public partial class ProductListCatalogWindow : Window
{
    BlApi.IBL? bl = BlApi.Factory.Get();
    static BO.Order order = new BO.Order();
    static IEnumerable<BO.OrderItem> orderItems = new List<BO.OrderItem>();
    IEnumerator<BO.OrderItem> enumerator = orderItems.GetEnumerator();
    static List<BO.OrderItem>itemlist=new List<BO.OrderItem>();
    static BO.OrderItem item=new BO.OrderItem();
    static bool flag = true;
     private void initializingCart()
    {
        order = bl.Order.Get(1);
        itemlist.Add(order.Item);
        flag = false;
    }
    Cart cart = new Cart();

    public ProductListCatalogWindow(IBL bl)
    {
        this.bl = bl;
        InitializeComponent();
        ProductsListView.ItemsSource = bl.Product.GetProductForLists();
        ComboBoxCategory.ItemsSource = Enum.GetValues(typeof(BO.Furniture));

    }

    private void Click_Show_Cart(object sender, RoutedEventArgs e)
    {
        try { new Customer.CustomerCart(bl, cart).Show(); this.Close(); }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Click_Add_To_Cart(object sender, RoutedEventArgs e)
     {
        BO.ProductForList? product = (sender as Button)?.DataContext as BO.ProductForList;
        try
        {
            if (cart.Items == null)
            {
                initializingCart();
                cart.Items = itemlist;
            }
            
            cart = bl.Cart.Add(cart, product.ID);
            
            MessageBox.Show("Added !");
            if (flag == false)
            {
                cart.Items = cart.Items.Where(x => x.Amount == 1).ToList();
                orderItems = cart.Items;
                IEnumerator<BO.OrderItem> enumerator = orderItems.GetEnumerator();
                while (enumerator.MoveNext())
                    item = (BO.OrderItem)enumerator.Current;
                cart.TotalPrice = item.Price;
                flag = true;
            }
            else
                bl.Cart.UpdatingSum(cart);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
            if ((BO.Furniture)ComboBoxCategory.SelectedItem == BO.Furniture.all)
                ProductsListView.ItemsSource = ProductsListView.ItemsSource = bl.Product.GetProductForLists();
        else ProductsListView.ItemsSource = bl.Product.GetSomeProduct((BO.Furniture)ComboBoxCategory.SelectedItem);

    }

}
