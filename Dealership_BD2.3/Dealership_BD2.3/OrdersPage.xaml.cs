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

namespace Dealership_BD2._3
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private DealershipEntities context = new DealershipEntities();
        public OrdersPage()
        {
            InitializeComponent();
            ordersDgr.ItemsSource = context.Orders.ToList();
            Cbx.ItemsSource = context.Orders.ToList();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            ordersDgr.ItemsSource = context.Orders.ToList().Where(item => item.OrderDate.Contains(text_search.Text));
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            ordersDgr.ItemsSource = context.Orders.ToList();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx.SelectedItem != null)
            {
                var selected = Cbx.SelectedItem as Orders;
                ordersDgr.ItemsSource = context.Orders.ToList().Where(item => item.OrderDate == selected.OrderDate);
            }
        }
    }
}