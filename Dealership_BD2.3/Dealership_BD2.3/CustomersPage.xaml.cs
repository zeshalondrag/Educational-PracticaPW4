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
    /// Логика взаимодействия для CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        private DealershipEntities context = new DealershipEntities();
        public CustomersPage()
        {
            InitializeComponent();
            customersDgr.ItemsSource = context.Customers.ToList();
            Cbx.ItemsSource = context.Customers.ToList();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            customersDgr.ItemsSource = context.Customers.ToList().Where(item => item.Email.Contains(text_search.Text));
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            customersDgr.ItemsSource = context.Customers.ToList();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx.SelectedItem != null)
            {
                var selected = Cbx.SelectedItem as Customers;
                customersDgr.ItemsSource = context.Customers.ToList().Where(item => item.CustomerSurname == selected.CustomerSurname);
            }
        }
    }
}