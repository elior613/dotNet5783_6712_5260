using BlApi;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.orders
{
    /// <summary>
    /// Logique d'interaction pour OrderList.xaml
    /// </summary>
    public partial class OrderList : Window, INotifyPropertyChanged
    {
        IBL bl;

        public OrderList(IBL bl)
        {
            this.bl = bl;
            this.orderForList = new ObservableCollection<BO.OrderForList?>(bl.Order.GetOrders());
            InitializeComponent();
            OrderListView.ItemsSource = orderForList;
        }

        private ObservableCollection<BO.OrderForList?> orderForList;
        public ObservableCollection<BO.OrderForList?> List
        {
            get => orderForList;
            set
            {
                orderForList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("List"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Order_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new OrderWindows.OrderWindow(bl, ((BO.OrderForList)OrderListView.SelectedItem).ID, orderForList, this.OrderListView.SelectedIndex).Show();


    }
}