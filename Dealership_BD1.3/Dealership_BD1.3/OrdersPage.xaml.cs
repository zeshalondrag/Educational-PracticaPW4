using System;
using System.Collections.Generic;
using System.Data;
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
using Dealership_BD1._3.DealershipDataSetTableAdapters;

namespace Dealership_BD1._3
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        OrdersTableAdapter context = new OrdersTableAdapter();
        public OrdersPage()
        {
            InitializeComponent();
            ordersDgr.ItemsSource = context.GetData();
            Cbx.ItemsSource = context.GetData();
            Cbx.DisplayMemberPath = "OrderDate";
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            ordersDgr.ItemsSource = context.SearchByOrderDate(text_search.Text);
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            ordersDgr.ItemsSource = context.GetData();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx.SelectedItem != null)
            {
                var id = (int)(Cbx.SelectedItem as DataRowView).Row[0];
                ordersDgr.ItemsSource = context.FillterByOrder(id);
            }
        }
    }
}