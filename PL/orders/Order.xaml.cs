using BlApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour cart.xaml
    /// </summary>
    public partial class Order : Window
    {
        IBL bl;
        int index;
        ObservableCollection<BO.OrderForList?> orders;
        int id;
        public Order(IBL bl, int id, ObservableCollection<BO.OrderForList?> list, int index)
        {
            this.bl = bl;
            this.index = index;
            this.orders = list;
            this.id = id;
            BO.Order order = bl.Order.Get(id);
            InitializeComponent();
            viewListOrderItem.ItemsSource = bl.Order.GetOrders();
            if (order.ShipDate == null) // I tried to use DataBinding with ButtonEnabledConverter but it doesn't work so sorry
                Delivery_Button.IsEnabled = false;
            else if (order.ShipDate != null && order.DeliveryDate == null)
            {
                Delivery_Button.IsEnabled = true;
                Ship_Button.IsEnabled = false;
            }
            else
            {
                Delivery_Button.IsEnabled = false;
                Ship_Button.IsEnabled = false;
            }
            this.OrderDetailsGrid.DataContext = order;

        }

        private void UpdateShipDate_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Order order = bl.Order.Update(id);
                orders[index] = new BO.OrderForList()
                {
                    AmountOfItems = order.AmountOfItem,
                    CostumerName = order.CostumerName,
                    ID = order.ID,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalPrice = order.TotalPrice,

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void UpdateDeliveryDate_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Order order = bl.Order.updateDelivery(id);
                orders[index] = new BO.OrderForList()
                {
                    AmountOfItems = order.AmountOfItem,
                    ID = order.ID,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalPrice = order.TotalPrice,
                    CostumerName= order.CostumerName,

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void viewListOrderItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
